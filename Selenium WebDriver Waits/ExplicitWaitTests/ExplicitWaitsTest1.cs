using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ExplicitWaitTests
{
    public class ExplicitWaitsTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl(" http://practice.bpbonline.com/ ");
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        }

        [TearDown]

        public void Teardown() 
        {  
            driver.Quit();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void Valid_SearchWithExplicitWait()
        {
            driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("keyboard");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            try
            {   
                driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(0);
                
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                //IWebElement buyNow=wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='bodyContent']//a/span[2]")));

                IWebElement product = wait.Until(e => e.FindElement(By.LinkText("Buy Now")));

                //buyNow.Click();

                product.Click();

                IWebElement productValue = driver.FindElement(By.XPath("//div[@class='contentText']//td//input"));

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 

                string productValueText=productValue.GetAttribute("value");


                Assert.That(productValueText, Is.EqualTo("1"), "The amount of product was not found in the cart page");
                Assert.IsTrue(driver.PageSource.Contains("1"));
                Assert.IsTrue(driver.PageSource.Contains("Sub-Total"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception:" + ex.Message);
            }
        }

        [Test, Order(2)] 
        public void NoValid_SearchWithExplicitWait()
        {
            driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("junk");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement buyNow = wait.Until(e => e.FindElement(By.LinkText("Buy Now")));

                buyNow.Click();

                Assert.Fail("The buy Now button was found for non-existing element");

            }
            catch(WebDriverTimeoutException ex)
            {
                Assert.Pass("The appropriate timeout exception was thrown");
            }
            catch(Exception ex) 
            {
                Assert.Fail("Unexpected exception:" + ex.Message);
            }
        }
    }
}