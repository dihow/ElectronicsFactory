using ElectronicsFactory;
using Xunit;

namespace ElectronicsFactoryTests
{
    public class OrderTests
    {
        [Fact]
        public void Test10_CreateOrder_Success()
        {
            var client = ClientRepository.GetClientById(1);
            var pcb = PcbRepository.GetPcbBySerialNumber("PCB-EMC-001");

            Assert.NotNull(client);
            Assert.NotNull(pcb);

            int originalPcbQuantity = pcb.TotalQuantity;
            int orderQuantity = 2;

            int orderId = 0;
            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                var order = new Order(
                    id: 0,
                    clientId: client.Id,
                    registrationDate: System.DateTime.Now,
                    status: "Не подтверждён",
                    totalAmount: pcb.Price * orderQuantity,
                    shipmentDate: null,
                    transportCompany: null
                );

                orderId = OrderRepository.AddOrder(order, transaction);

                var orderItem = new OrderItem(
                    id: 0,
                    orderId: orderId,
                    pcbId: pcb.Id,
                    quantity: orderQuantity,
                    pricePerPcb: pcb.Price
                );
                OrderRepository.AddOrderItem(orderItem, transaction);

                pcb.TotalQuantity -= orderQuantity;
                PcbRepository.UpdatePcb(pcb, transaction);

                AdditionalRepository.CreatePcbMovement("Списание", pcb.Id, orderQuantity,
                    $"Списание для заказа №{orderId}", transaction);
            });

            var createdOrder = OrderRepository.GetOrderById(orderId);
            Assert.NotNull(createdOrder);
            Assert.Equal(client.Id, createdOrder.ClientId);
            Assert.Equal("Не подтверждён", createdOrder.Status);

            var updatedPcb = PcbRepository.GetPcbById(pcb.Id);
            Assert.NotNull(updatedPcb);
            Assert.Equal(originalPcbQuantity - orderQuantity, updatedPcb.TotalQuantity);

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                OrderRepository.DeleteOrderWithRestoreStock(orderId, transaction);
            });
        }

        [Fact]
        public void Test11_UpdateOrderStatus_Success()
        {
            var client = ClientRepository.GetClientById(1);
            Assert.NotNull(client);

            int orderId = 0;
            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                var order = new Order(
                    id: 0,
                    clientId: client.Id,
                    registrationDate: System.DateTime.Now,
                    status: "Не подтверждён",
                    totalAmount: 1000.00m,
                    shipmentDate: null,
                    transportCompany: null
                );
                orderId = OrderRepository.AddOrder(order, transaction);
            });

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                OrderRepository.UpdateOrderStatus(orderId, "Отправлен");
            });

            var updatedOrder = OrderRepository.GetOrderById(orderId);
            Assert.NotNull(updatedOrder);
            Assert.Equal("Отправлен", updatedOrder.Status);

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                OrderRepository.DeleteOrder(orderId, transaction);
            });
        }
    }
}
