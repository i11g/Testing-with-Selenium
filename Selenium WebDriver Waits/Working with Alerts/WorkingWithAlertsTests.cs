using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Working_with_Alerts
{
    public class WorkingWithAlertsTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        { 
            driver=new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
        }
        [TearDown] public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void HandleBasicAlertTest()
        {
            driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Alert')]")).Click();

            IAlert alert = driver.SwitchTo().Alert();

            Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"), "Alert text is not as expected");

            alert.Accept();

         var   resultText =driver.FindElement(By.XPath("//p[@id='result']")).Text;
            Assert.That(resultText, Is.EqualTo("You successfully clicked an alert"));
        }

        [Test, Order(2)] 

        public void HandleJavaScriptConfirmAlerts()
        {
            driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Confirm')]")).Click(); 

            IAlert alert=driver.SwitchTo().Alert();

            Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"));

            alert.Accept();

            var resultText = driver.FindElement(By.XPath("//p[@id='result']")).Text;
            Assert.That(resultText, Is.EqualTo("You clicked: Ok"));

            driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Confirm')]")).Click();

            alert = driver.SwitchTo().Alert();

            alert.Dismiss();

            var resultTextDismiss = driver.FindElement(By.XPath("//p[@id='result']")).Text;
            Assert.That(resultTextDismiss, Is.EqualTo("You clicked: Cancel"), "Result message was not as expected");

        }

        [Test, Order(3)] 

        public void HandleJavaScript_PromptAlerts()
        {
            driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Prompt')]")).Click();

            IAlert alert = driver.SwitchTo().Alert();

            Assert.That(alert.Text, Is.EqualTo("I am a JS prompt"), "Alert text was not as expected");

            string inputText = "Hi, dude";
            alert.SendKeys(inputText); 

            var resultTextDismiss = driver.FindElement(By.XPath("//p[@id='result']")).Text;
            Assert.That(resultTextDismiss, Is.EqualTo("You entered: Hi, dude"), "Result message was not as expected");

        }
    }
}