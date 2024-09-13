

namespace POMExercise.Tests
{
    public class HiddenMenuPageTests: BasePageTests
    {
        [Test] 

        public void TestHiidenMenuOpensCorrectlly()
        {
            LoginMethod("standard_user", "secret_sauce");
            hiddenMenuPage.ClickHamburgerMenu();

            Assert.That(hiddenMenuPage.IsMenuOpen(), Is.True, "Hidden menu page is not open");
        }
        
        public void TestUserCanLogOut()
        {
            LoginMethod("standard_user", "secret_sauce");
            hiddenMenuPage.ClickLogoutButton();
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));

        }
    }
}
