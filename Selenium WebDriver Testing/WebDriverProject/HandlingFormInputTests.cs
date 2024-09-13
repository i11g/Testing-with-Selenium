using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverProject
{
    public class HandlingFormInputTests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
        }

        [TearDown] 
        public void Teardown() 
        { 
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void HandlingFormInputTest()
        {
            //click on My Account Button

            driver.FindElements(By.XPath("//span[@class='ui-button-text']"))[2].Click(); 
            //click on Continue Button
            driver.FindElement(By.LinkText("Continue")).Click();

            //click on Gender Radio Button

            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@value='m']")).Click();
            //driver.FindElement(By.XPath("//input[@type='radio'][@value='m']")).Click();

            //fill in the First and Last Name fields 

            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='firstname']")).SendKeys("Gosho");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='lastname']")).SendKeys("Petrov");

            //fill in the Date field and email adress
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@class='hasDatepicker']")).SendKeys("05/24/1990");
            //driver.FindElement(By.Id("dob")).SendKeys("05/24/1998");

            //fill in email adress
            //Generate random number
            Random random = new Random();
            int rndNumber = random.Next(0, 999);
            //Generate random email
            string rndEmail = "fioana" + rndNumber + "@example.com";
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='email_address']")).SendKeys(rndEmail);
            //driver.FindElement(By.Name("email_address")).SendKeys(rndEmail);

            //fill in company 

            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='company']")).SendKeys("Oracle");
            
            //adress 
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='street_address']")).SendKeys("Street");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='suburb']")).SendKeys("random suburb");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='postcode']")).SendKeys("00002");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='city']")).SendKeys("Kaspichan");
            driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='state']")).SendKeys("Vratca"); 

            //Select Element


        }
    }
}