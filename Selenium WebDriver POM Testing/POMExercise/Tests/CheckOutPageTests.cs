

using POMExercise.Pages;

namespace POMExercise.Tests
{
    public class CheckOutPageTests: BasePageTests
    {
        [SetUp] 

        public void SetUp()
        {
            LoginMethod("standard_user", "secret_sauce");
            inventoryPage.AddToCartByIndex(3);
            inventoryPage.ClickCart();
            cartPage.ClickCheckOut();
            //checkOutPage.FillFirstName("ggg");
            //checkOutPage.FillInLastName("iii");
            //checkOutPage.FillInZipCode("1000");
            //checkOutPage.ClickContinueButton();
        }

        [Test] 

        public void TestCheckOutPageIsLoaded()
        {
            Assert.True(checkOutPage.IsPageLoaded(), "Check out page was not loaded correctlly");
        }


        [Test]

        public void TestUserCanContinueToTheNextSteps()
        {
            checkOutPage.FillFirstName("ggg");
            checkOutPage.FillInLastName("iii");
            checkOutPage.FillInZipCode("1000");
            checkOutPage.ClickContinueButton();
            Assert.True(checkOutPage.IsPageLoaded(), "Check out page was not loaded correctlly");
        }


        [Test]
        public void TestUserCanCompleteTheOrder ()
        {
            checkOutPage.FillFirstName("ggg");
            checkOutPage.FillInLastName("iii");
            checkOutPage.FillInZipCode("1000");
            checkOutPage.ClickContinueButton();
            checkOutPage.ClickFinishButton();

            Assert.True(checkOutPage.CheckCompleteHeader(), "Checkout Page Header is not correct");
        }
    }
}
