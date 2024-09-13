using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BPBSiteTests
{
    public class HadlingFormInputTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }

        [TearDown]

        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test1()
        {
            driver.FindElement(By.XPath("//a[@id='tdb3']//span[@class='ui-button-text']")).Click();
            driver.FindElement(By.XPath("//a[@id='tdb4']//span[@class='ui-button-text']")).Click();

            driver.FindElement(By.XPath("//input[@value='m']")).Click();
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='firstname']")).SendKeys("Pesho");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='lastname']")).SendKeys("Geshkov");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@id='dob']")).SendKeys("01/10/2020");

            Random random = new Random();
            int randomNumber = random.Next(9, 999);
            string randomEmail = "pesho" + randomNumber.ToString() + "example.com";

            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='email_address']")).SendKeys(randomEmail);
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='company']")).SendKeys("One");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='street_address']")).SendKeys("Sofiiski");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='suburb']")).SendKeys("Sofiinski");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='postcode']")).SendKeys("1000");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='city']")).SendKeys("Sofia");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='state']")).SendKeys("Sofia1");

            IWebElement coutryDropdown = driver.FindElement(By.Name("country"));
            SelectElement selectcountry = new SelectElement(coutryDropdown);
            selectcountry.SelectByText("United Kingdom");

            //new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("United Kingdom");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='telephone']")).SendKeys("123456");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='newsletter']")).Click();
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='password']")).SendKeys("1980");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='confirmation']")).SendKeys("1980");

            driver.FindElement(By.XPath("//button[@id='tdb4']//span[@class='ui-button-text']")).Click();

            string textCreatedPage = driver.FindElement(By.CssSelector("h1")).Text;

            Assert.That(textCreatedPage, Is.EqualTo("Your Account Has Been Created!"), "Account creation failed");


        }
    }
}