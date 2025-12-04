using Xunit;
using ElectronicsFactory;

namespace ElectronicsFactoryTests
{
    public class AuthorizationTest : BaseTest
    {
        [Fact]
        public void Test1_AdminLogin_Success()
        {
            bool result = AdditionalRepository.TryLoggingIn("admin", "adm");

            Assert.True(result);
        }

        [Fact]
        public void Test2_AdminWrongPassword_Failure()
        {
            bool result = AdditionalRepository.TryLoggingIn("admin", "123");

            Assert.False(result);
        }
    }
}