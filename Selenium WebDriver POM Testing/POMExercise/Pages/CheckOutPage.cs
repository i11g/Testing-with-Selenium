using OpenQA.Selenium;


namespace POMExercise.Pages
{
    public class CheckOutPage : BasePage
    {
        private readonly By firstNameField = By.XPath("//input[@id='first-name']");
        private readonly By lastNameFiled= By.XPath("//input[@id='last-name']");
        private readonly By zipCodeField = By.XPath("//input[@id='postal-code']");
        private readonly By continueButton = By.XPath("//*[@id=\"continue\"]");
        private readonly By finishButton = By.XPath("//button[@id='finish']");
        private readonly By completeHeader = By.XPath("//h2[@class='complete-header']");
        public CheckOutPage(IWebDriver driver) : base(driver) 
        { 
            
        } 

        public void FillFirstName(string firstName)
        {
            Type(firstNameField, firstName);
        }

        public void FillInLastName(string LastName)
        {
            Type(lastNameFiled, LastName);
        } 

        public void FillInZipCode(string ZipCode)
        {
            Type(zipCodeField, ZipCode);
        } 

        public void ClickContinueButton()
        {
            Click(continueButton);
        } 

        public void ClickFinishButton()
        {
            Click(finishButton);
        } 

        public bool CheckCompleteHeader()
        {
            return GetText(completeHeader) == "Thank you for your order!";
        } 

        public bool IsPageLoaded()
        {
            return driver.Url.Contains("checkout-step-one.html") || 
                driver.Url.Contains("checkout-step-two.html");
        }
    }
}
 