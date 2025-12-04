using ElectronicsFactory;
using Xunit;

namespace ElectronicsFactoryTests
{
    public class ClientTests
    {
        [Fact]
        public void Test8_AddIndividualClient_Success()
        {
            var client = new Client(
                id: 0,
                type: "Физическое лицо",
                phone: "79160000000",
                email: "test@test.com",
                inn: "123450789012"
            );

            int clientId = 0;
            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                clientId = ClientRepository.AddClient(client, transaction);

                var individual = new Individual(
                    clientId: clientId,
                    fullName: "Иванов Иван Иванович",
                    address: "г. Москва, ул. Тестовая, д. 1",
                    age: 25
                );
                ClientRepository.AddIndividual(individual, transaction);
            });

            var retrievedClient = ClientRepository.GetClientById(clientId);
            var retrievedIndividual = ClientRepository.GetIndividualById(clientId);

            Assert.NotNull(retrievedClient);
            Assert.NotNull(retrievedIndividual);
            Assert.Equal("Физическое лицо", retrievedClient.Type);
            Assert.Equal("Иванов Иван Иванович", retrievedIndividual.FullName);
            Assert.Equal(25, retrievedIndividual.Age);

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                ClientRepository.DeleteClientWithDependencies(clientId, transaction);
            });
        }

        [Fact]
        public void Test9_AddLegalEntityClient_Success()
        {
            var client = new Client(
                id: 0,
                type: "Юридическое лицо",
                phone: "79161111111",
                email: "company@test.com",
                inn: "1234567890"
            );

            int clientId = 0;
            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                clientId = ClientRepository.AddClient(client, transaction);

                var legalEntity = new LegalEntity(
                    clientId: clientId,
                    companyName: "ООО Тестовая компания",
                    contactPerson: "Петров П.П.",
                    legalAddress: "г. Москва, ул. Юридическая, д. 10",
                    actualAddress: "г. Москва, ул. Фактическая, д. 11"
                );
                ClientRepository.AddLegalEntity(legalEntity, transaction);
            });

            var retrievedClient = ClientRepository.GetClientById(clientId);
            var retrievedLegalEntity = ClientRepository.GetLegalEntityById(clientId);

            Assert.NotNull(retrievedClient);
            Assert.NotNull(retrievedLegalEntity);
            Assert.Equal("Юридическое лицо", retrievedClient.Type);
            Assert.Equal("ООО Тестовая компания", retrievedLegalEntity.CompanyName);

            Database.TransactionManager.ExecuteInTransaction(transaction =>
            {
                ClientRepository.DeleteClientWithDependencies(clientId, transaction);
            });
        }
    }
}
