using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WorkingWith_Iframes
{
    public class WorkingWithIFramesTests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}