using ElectronicsFactory;

namespace ElectronicsFactoryTests
{
    public class BaseTest
    {
        public BaseTest()
        {
            InitializeTestEnvironment();
        }

        private void InitializeTestEnvironment()
        {
            var connectionString = "Host=localhost;Database=ElectronicsFactory;Port=5432;Username=postgres;Password=virtual";
            Database.Initialize(connectionString);
        }
    }
}
