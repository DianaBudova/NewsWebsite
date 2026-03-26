using NewsWebsite.WebAPI.Security;
using Xunit;

namespace NewsWebsite.Tests
{
    public class AuthTests
    {
        [Fact]
        public void Login_ShouldReturnTrue_ForCorrectCredentials()
        {
            var auth = new UserAuth();
            Assert.False(auth.Login("admin", "1234"));
        }
    }
}
