using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenTests1
{
    public class DataTests
    {   
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/");
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(15);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void DataTest()
        {
           
        }
    }
}