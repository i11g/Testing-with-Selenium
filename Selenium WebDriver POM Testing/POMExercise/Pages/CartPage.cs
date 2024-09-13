using OpenQA.Selenium;


namespace POMExercise.Pages
{
    public class CartPage : BasePage
    {
        private readonly By cartItem = By.XPath("//div[@class='cart_item']");
        private readonly By checkOutButton = By.XPath("//button[@id='checkout']");
        public CartPage(IWebDriver driver) : base (driver)
        {
            
        } 

        public bool IsCartItemDisplayed()
        {
            return FindElement(cartItem).Displayed;
        } 

        public void ClickCheckOut()
        {
            Click(checkOutButton);
        }
    }
}
