using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_SumTwoNumbersApplicationTests
{
    public class SumNumberPage
    {
        private readonly IWebDriver driver;

        public SumNumberPage(IWebDriver driver)
        {
            this.driver = driver;
            
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        }

        public const string PageUrl = "https://ba70f53d-2d48-46b9-9c53-ae8f297e0385-00-3tk73h0xk6jwy.worf.replit.dev/";

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement firsNumber => driver.FindElement(By.XPath("//input[@id='number1']")); 
        public IWebElement secondNumber => driver.FindElement(By.XPath("//input[@id='number2']"));

        public IWebElement calculateButton => driver.FindElement(By.XPath("//input[@id='calcButton']"));

        public IWebElement resetButton => driver.FindElement(By.XPath("//input[@id='resetButton']"));

        public IWebElement divresult => driver.FindElement(By.XPath("//div[@id='result']"));

        public void ResetPage()
        {
            resetButton.Click();
        }

        public bool EmpryPage()
        {
            return firsNumber.Text + secondNumber.Text + divresult.Text =="";
        }

        public string AddNumber(string num1, string num2)
        {
            firsNumber.SendKeys(num1);
            secondNumber.SendKeys(num2);
            calculateButton.Click();

            return divresult.Text;
        }
    }
}
