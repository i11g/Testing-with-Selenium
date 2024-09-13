using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace WorkingWithWebTables
{
    public class WebTablesTests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/ ");
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
            IWebElement productionTable= driver.FindElement(By.XPath("//div[@class='contentText']//table"));

            ReadOnlyCollection<IWebElement> tableRows=productionTable.FindElements(By.XPath("//tbody//tr")); 

            string path=System.IO.Directory.GetCurrentDirectory() + "/productionInformation.csv";

            if(File.Exists(path))
                File.Delete(path);

            foreach (var row in tableRows)
            {
                ReadOnlyCollection<IWebElement> tableColumns = row.FindElements(By.XPath(".//td"));

                foreach (var column in tableColumns)
                {
                    string data = column.Text;
                    string[] productionInfo = data.Split("\n");
                    string finalProductionInfo = productionInfo[0].Trim() + "," + productionInfo[1].Trim() +"\n";

                    File.AppendAllText(path, finalProductionInfo);
                }
            }

            Assert.IsTrue(File.Exists(path), "CSV file wa not created");
            Assert.IsTrue(new FileInfo(path).Length > 0, "CSV file is empty");

        }
    }
}