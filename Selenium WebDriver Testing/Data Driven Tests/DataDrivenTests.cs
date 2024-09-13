using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Data_Driven_Tests
{
    [TestFixture]
    public class DataDrivenTests
    {
        IWebDriver driver;
        IWebElement textBoxFirstNum;
        IWebElement textBoxSecondNum;
        IWebElement dropDownOperation;
        IWebElement calcButton;
        IWebElement resetButton;
        IWebElement divResult;

        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/");

            textBoxFirstNum = driver.FindElement(By.Id("number1"));
            textBoxSecondNum = driver.FindElement(By.Id("number2"));
            dropDownOperation = driver.FindElement(By.Id("operation"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            resetButton = driver.FindElement(By.Id("resetButton"));
            divResult = driver.FindElement(By.Id("result")); 
        }

        public void PerformCalculation(string firstNumebr, string secondNumebr, string operation, string expectedResult)
        {
            resetButton.Click(); 

            if(!string.IsNullOrEmpty(firstNumebr))
            {
                textBoxFirstNum.SendKeys(firstNumebr);
            }

            if(!string.IsNullOrEmpty(secondNumebr))
            {
                textBoxSecondNum.SendKeys(secondNumebr);
            } 

            if(!string.IsNullOrEmpty(operation))
            {
                new SelectElement(dropDownOperation).SelectByText(operation);
            } 

            calcButton.Click();

            Assert.That(expectedResult, Is.EqualTo(divResult.Text));
        }


        [Test]
        [TestCase("5", "+ (sum)", "10", "Result: 15")]
        [TestCase("3.5", "- (subtract)", "1.2", "Result: 2.3")]
        [TestCase("2e2", "* (multiply)", "1.5", "Result: 300")]
        [TestCase("5", "/ (divide)", "0", "Result: Infinity")]
        [TestCase("invalid","+ (sum)", "10", "Result: invalid input")]
        public void TestsNumebrCalculator(string firstNumber, string operation, string secondNumber, string result)
        {
            PerformCalculation(firstNumber, secondNumber, operation, result);
        }

        [OneTimeTearDown] 

        public void TearDown ()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}