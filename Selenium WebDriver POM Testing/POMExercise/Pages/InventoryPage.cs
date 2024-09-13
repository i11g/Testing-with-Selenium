using OpenQA.Selenium;

namespace POMExercise.Pages
{
    public class InventoryPage : BasePage 
    {

        private readonly By shopingCart = By.XPath("//a[@class='shopping_cart_link']");
        //private readonly By shpCart = By.CssSelector(".shopping_cart_link");
       //private readonly By productsTitle = By.XPath("//span[@class='title']");
        private readonly By proTitle = By.ClassName("title");
        private readonly By productItems = By.XPath("//div[@class='inventory_item']");
        //private readonly By proItems = By.CssSelector(".inventory_item");
        public InventoryPage(IWebDriver driver) : base(driver)
        {
            
        } 

        public void AddToCartByIndex(int itemindex)
        {
            var itemToAdd = By.XPath($"//div[@class='inventory_item'][{itemindex}]//button");
            //div[@class='inventory_list']//div[@class='inventory_item']{itemindex}//button"
            Click(itemToAdd);
        } 

        public void AddToCartByName(string productName)
        {
            var itemToAdd = By.XPath($"//div[text()='{productName}']/ancestor::div[@class='inventory_item']//button");
            Click(itemToAdd);
        } 

        public void ClickCart()
        {
            Click(shopingCart);
        } 

        public bool IsInventoryDisplayed()
        {
            return FindElements(productItems).Any(); 
        } 

        public bool IsPageLoaded()
        {
            return GetText(proTitle) == "Products" && driver.Url.Contains("inventory.html");
        }
    }
}
