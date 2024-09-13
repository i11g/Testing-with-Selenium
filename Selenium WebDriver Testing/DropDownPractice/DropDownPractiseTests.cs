using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace DropDownPractice
{
    public class DropDownPracticeTests 
    {
        private WebDriver driver; 

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);

        }
        [TearDown] 

        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
        
        [Test]
        public void DropDownPractice()
        {
            string path=Directory.GetCurrentDirectory()+ "/manufacturer.txt";

            if(File.Exists(path)) 
            {
                File.Delete(path);
            }

            SelectElement dropDown =new SelectElement(driver.FindElement(By.XPath("//form[@name='manufacturers']//select")));

            IList<IWebElement> dropDownManufacOptions=dropDown.Options;

            List<string> dropDownManuAsString=new List<string>();

            foreach (var dropOptions in dropDownManufacOptions)
            {
                dropDownManuAsString.Add(dropOptions.Text);
            }
            dropDownManuAsString.RemoveAt(0);

            foreach (var dropDownMan in dropDownManuAsString)
            {
                dropDown.SelectByText(dropDownMan);
                dropDown = new SelectElement(driver.FindElement(By.XPath("//form[@name='manufacturers']//select")));

                if (driver.PageSource.Contains("There are no products available in this category."))
                {
                    File.AppendAllText(path, $"The manufacturer{dropDownMan} has no products");
                }
                else
                {
                    //Create table Element 

                    IWebElement table=driver.FindElement(By.ClassName("productListingData"));

                    //Take the rows in the table
                    File.AppendAllText(path, $"\n\n The manufacturer {dropDownMan} products are listed --\n");
                    ReadOnlyCollection<IWebElement> rows =table.FindElements(By.XPath("//tbody//tr"));

                    foreach (var row in rows)
                    {
                        File.AppendAllText(path, row.Text + "\n");
                    }

                }
            }
        }
    }
}