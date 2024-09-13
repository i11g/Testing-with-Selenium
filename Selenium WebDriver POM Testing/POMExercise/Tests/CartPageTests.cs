

namespace POMExercise.Tests
{
    public class CartPageTests :BasePageTests
    {
        [SetUp]

        public void SetUp()
        {
            LoginMethod("standard_user", "secret_sauce");
            inventoryPage.AddToCartByIndex(3);
            inventoryPage.ClickCart();
        }


        [Test] 

        public void TestCartItemDisplayed()
        {
            Assert.True(cartPage.IsCartItemDisplayed(), "Cart item is not displayed");    
        }

        [Test] 

        public void TestClickCheckOutButton()
        {
            cartPage.ClickCheckOut();
            Assert.That(checkOutPage.IsPageLoaded(), Is.True, "Cheout page is not displayed");
        }

    }
}
