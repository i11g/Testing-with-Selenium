

namespace POMExercise.Tests
{
    public class LoginPageTests :BasePageTests
    {
        [Test] 

        public void TestLoginWithValidCredentials()
        {
            LoginMethod("standard_user", "secret_sauce");

            Assert.That(inventoryPage.IsPageLoaded, Is.True, "Inventory page was not loaded");
        }

        [Test] 
        public void TestLoginWithInvalidCredentilas ()
        {
            LoginMethod("invalid", "secret_sauce");

            Assert.That(loginPage.ErrorMessage, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"), "Error message " +
                "is not correct");
            Assert.That(loginPage.ErrorMessage().Contains("Username and password do not match any user in " +
                "this service"));         
        }

        [Test] 

        public void TestWIthLockedUser ()
        {
            LoginMethod("locked_out_user", "secret_sauce");
            Assert.That(loginPage.ErrorMessage, Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));

            var error=loginPage.ErrorMessage();
            Assert.That(error.Contains("Sorry, this user has been locked out."));
        }
    }
}
