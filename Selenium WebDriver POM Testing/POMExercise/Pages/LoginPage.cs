using OpenQA.Selenium;

namespace POMExercise.Pages
{
    public class LoginPage : BasePage 
    {

        private readonly By userNameFiled = By.XPath("//input[@id='user-name']");
        //private readonly By useName = By.Id("user-name");
        private readonly By passwordFiled = By.XPath("//input[@id='password']");
        //private readonly By password = By.Id("password");
        private readonly By loginButton = By.XPath("//input[@id='login-button']");
        //private readonly By loginbutt = By.Id("login-button");
        private readonly By errorMessage = By.XPath("//div[@class='error-message-container error']//h3");
        //private readonly By errorMessage = By.CssSelector(",error-message-container error");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        } 

        public void InputUserName(string username)
        {
            Type(userNameFiled, username);
        } 

        public void InputPassword(string password)
        {
            Type(passwordFiled, password);
        } 

        public void ClickLoginButton()
        {
            Click(loginButton);
        } 

        public string ErrorMessage()
        {
            return GetText(errorMessage);
        } 

        public void LoginUser(string username, string password)
        {
            InputUserName(username);
            InputPassword(password);
            ClickLoginButton();
        }
    }
}
