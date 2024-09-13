

namespace POMExercise.Tests
{
    public class InventoryPageTests :BasePageTests
    {
        [SetUp]

        public void SetUp()
        {
            LoginMethod("standard_user", "secret_sauce");
        }

        [Test] 

        public void TestInventoryDisplay()
        {
                  
            Assert.That(inventoryPage.IsInventoryDisplayed(), Is.EqualTo(true), 
                "Inventory page has no items displayed");
        }

        [Test]

        public void TestAddToCartByIndex()
        {
            inventoryPage.AddToCartByIndex(3);
            inventoryPage.ClickCart();
            Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "Cart Items was not added in the cart page");
            
        }

        [Test] 

        public void TestAddToCartByName()
        {
            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.ClickCart();
            Assert.That(cartPage.IsCartItemDisplayed, Is.True, "Cart items are missing");
        }

        [Test]

        public void TestPageTitle()
        {
            Assert.That(inventoryPage.IsPageLoaded(), Is.EqualTo(true), "Page titile is not displayed");
        }

    }
}
