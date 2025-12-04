using ElectronicsFactory;
using Xunit;

namespace ElectronicsFactoryTests
{
    public class PcbTests : BaseTest
    {
        [Fact]
        public void Test3_AddNewPcb_Success()
        {
            var newPcb = new Pcb(
                id: 0,
                name: "Тестовая плата",
                serialNumber: "TEST-001",
                batch: "TEST-BATCH",
                description: "Тестовая плата для тестирования",
                price: 1000.00m,
                totalQuantity: 10,
                manufactureDate: DateTime.Now,
                length: 50.0m,
                width: 30.0m,
                layersCount: 2,
                comment: "Тестовый комментарий",
                imagePath: null
            );

            int pcbId = 0;
            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                pcbId = PcbRepository.AddPcb(newPcb, transaction);
            });

            Assert.True(pcbId > 0);

            var retrievedPcb = PcbRepository.GetPcbById(pcbId);
            Assert.NotNull(retrievedPcb);
            Assert.Equal("Тестовая плата", retrievedPcb.Name);
            Assert.Equal("TEST-001", retrievedPcb.SerialNumber);
            Assert.Equal(10, retrievedPcb.TotalQuantity);

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                PcbRepository.DeletePcb(pcbId, transaction);
            });
        }

        [Fact]
        public void Test4_UpdatePcbQuantity_Success()
        {
            var existingPcb = PcbRepository.GetPcbBySerialNumber("PCB-EMC-001");
            Assert.NotNull(existingPcb);

            int oldQuantity = existingPcb.TotalQuantity;
            int newQuantity = oldQuantity + 5;

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                existingPcb.TotalQuantity = newQuantity;
                PcbRepository.UpdatePcb(existingPcb, transaction);
            });

            var updatedPcb = PcbRepository.GetPcbById(existingPcb.Id);
            Assert.NotNull(updatedPcb);
            Assert.Equal(newQuantity, updatedPcb.TotalQuantity);

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                existingPcb.TotalQuantity = oldQuantity;
                PcbRepository.UpdatePcb(existingPcb, transaction);
            });
        }

        [Fact]
        public void Test5_FilterPcbsByName_Success()
        {
            var pcbs = PcbRepository.GetPcbsPage(10, 1, "Bluetooth");

            Assert.NotEmpty(pcbs);
            Assert.All(pcbs, p => Assert.Contains("Bluetooth", p.Name, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
