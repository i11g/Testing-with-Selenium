using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace Working_With_Windows1
{
    public class WorkingWithWindowsTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows ");
        }

        [TearDown] 

        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void HandleMultipleWindows_Test()
        {
            driver.FindElement(By.XPath("//div[@class='example']//a")).Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            Assert.That(windowHandles.Count, Is.EqualTo(2), "The windows are not open");

            driver.SwitchTo().Window(windowHandles[1]);

          var  newWindowContent=driver.FindElement(By.XPath("//div[@class='example']//h3")).Text;

            Assert.That(newWindowContent, Is.EqualTo("New Window"));

            string path = Path.Combine(Directory.GetCurrentDirectory(), "window.txt"); 
            if(File.Exists(path))
            {
                File.Delete(path);
            }

            File.AppendAllText(path, "Window hadle for new window:" + driver.CurrentWindowHandle + "\n\n");
            File.AppendAllText(path, "The page content:" + newWindowContent + "\n\n");

            driver.Close();

            driver.SwitchTo().Window(windowHandles[0]);

            var originalWindowContent = driver.FindElement(By.XPath("//div[@class='example']//h3")).Text;
            var originalContent = driver.PageSource;

            Assert.IsTrue(originalContent.Contains("Opening a new window"));
            Assert.That(originalWindowContent, Is.EqualTo("Opening a new window"));

            File.AppendAllText(path, "Original window handle: " + driver.CurrentWindowHandle + "\n\n"); 
            File.AppendAllText(path, "Original page content " + originalWindowContent + "\n\n");
        }

        [Test, Order(2)]

        public void NoSuchWindowException()
        {
            driver.FindElement(By.XPath("//div[@class='example']//a")).Click();
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            driver.SwitchTo().Window(windowHandles[1]);

            driver.Close();

            try
            {
                driver.SwitchTo().Window(windowHandles[1]);
            }
            catch(NoSuchWindowException ex) 
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");
                File.AppendAllText(path, "NoSuchWindowException caugth:" + ex.Message + "\n\n");
                Assert.Pass("NoSuchWindowException was correctly handled");
            }
            catch(Exception ex)
            {
                Assert.Fail("An unknown exception was thorwn:" + ex.Message);
            }
            finally
            {
                driver.SwitchTo().Window(windowHandles[0]);
            }
        }
    }
}