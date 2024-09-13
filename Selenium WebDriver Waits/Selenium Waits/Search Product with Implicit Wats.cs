using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Waits
{
    public class SearchProductWithImplicitWaits  
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com");
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        }

        [TearDown] 
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void SearchProduct_Keyboard()
        {
            driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("keyboard");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            try
            {
                driver.FindElement(By.XPath("//td[@align='center']//span//span[2]")).Click();
                var text = driver.FindElement(By.XPath("//form[@name='cart_quantity']//a//strong")).Text;

                Assert.That(driver.PageSource.Contains("keyboard"), "The product keyboard was not found");
                Assert.That(text, Is.EqualTo("Microsoft Internet Keyboard PS/2"),  "The text is not displayed");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }

        [Test, Order(2)] 

        public void SearchProduct_JunkShouldFail()
        {

            driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("junk");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click(); 

            try
            {
                driver.FindElement(By.LinkText("Buy Now")).Click();

               
            }
            catch(NoSuchElementException ex)
            {
                Assert.Pass("Expected NoSuchElementExeption was thrown.");
            }
            catch(Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }
    }
}