using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace POM_SumTwoNumbersApplicationTests
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); 
        }

        [Test]
        public void AddTwoNumberTest_ValidUnput()
        {
            var sumNumberPage=new SumNumberPage(driver);

            sumNumberPage.OpenPage();

            var result=sumNumberPage.AddNumber("5", "8");

            Assert.That(result, Is.EqualTo("Sum: 13"));
        }

        [Test]

        public void AddTwoNumbersTest_InvalidInput()
        {
            var sumPage=new SumNumberPage(driver);

            sumPage.OpenPage();
            var result=sumPage.AddNumber("kl", "oo");

            Assert.That(result, Is.EqualTo("Sum: invalid input"));
        }

        [Test] 

        public void Test_FormReset()
        {
            var sumPage = new SumNumberPage(driver);

            sumPage.OpenPage();

            var result = sumPage.AddNumber("4", "5");

            Assert.That(result, Is.EqualTo("Sum: 9"));

            sumPage.ResetPage();

            Assert.True(sumPage.EmpryPage());
        }
    }
}