using ElectronicsFactory;
using Xunit;

namespace ElectronicsFactoryTests
{
    public class ComponentTests : BaseTest
    {
        [Fact]
        public void Test6_AddResistorWithSpecifications_Success()
        {
            var resistor = new Component(
                id: 0,
                name: "Тестовый резистор 1кОм",
                manufacturer: "Тестовый производитель",
                price: 2.50m,
                type: "Резистор",
                stockQuantity: 100,
                createdAt: System.DateTime.Now
            );

            int componentId = 0;
            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                componentId = PcbRepository.AddComponent(resistor, transaction);

                var specs = new[]
                {
                    new ComponentSpecification(0, componentId, ComponentSpecification.RESISTANCE, "1000"),
                    new ComponentSpecification(0, componentId, ComponentSpecification.TOLERANCE, "5"),
                    new ComponentSpecification(0, componentId, ComponentSpecification.POWER, "0.25")
                };

                foreach (var spec in specs)
                {
                    PcbRepository.AddComponentSpecification(spec, transaction);
                }
            });

            var retrievedComponent = PcbRepository.GetComponentById(componentId);
            Assert.NotNull(retrievedComponent);
            Assert.Equal("Резистор", retrievedComponent.Type);

            var specifications = PcbRepository.GetComponentSpecifications(componentId);
            Assert.Equal(3, specifications.Count);
            Assert.Contains(specifications, s => s.Specification == ComponentSpecification.RESISTANCE);

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                PcbRepository.DeleteComponentWithCleanup(componentId, transaction);
            });
        }

        [Fact]
        public void Test7_UpdateComponentStock_Success()
        {
            var component = PcbRepository.GetComponentById(2);
            Assert.NotNull(component);

            int oldQuantity = component.StockQuantity;
            int newQuantity = oldQuantity + 100;

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                component.StockQuantity = newQuantity;
                PcbRepository.UpdateComponent(component, transaction);
            });

            var updatedComponent = PcbRepository.GetComponentById(component.Id);
            Assert.NotNull(updatedComponent);
            Assert.Equal(newQuantity, updatedComponent.StockQuantity);

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                component.StockQuantity = oldQuantity;
                PcbRepository.UpdateComponent(component, transaction);
            });
        }
    }
}
