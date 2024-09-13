using OpenQA.Selenium;


namespace POMExercise.Pages
{
    public class HiddenMenuPage : BasePage 
    {
        private readonly By hamburgerButton = By.XPath("//button[@id='react-burger-menu-btn']");
        private readonly By logoutButton = By.XPath("//a[@id='logout_sidebar_link']");
        public HiddenMenuPage(IWebDriver driver) : base(driver)
        {
            
        }

        public void ClickHamburgerMenu()
        {
            Click(hamburgerButton);
        }

        public void ClickLogoutButton()
        {
            Click(logoutButton);
        }

        public bool IsMenuOpen()
        {
            return FindElement(logoutButton).Displayed;
        }
    }
}
