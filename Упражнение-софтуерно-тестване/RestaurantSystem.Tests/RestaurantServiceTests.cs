using NUnit.Framework;

namespace RestaurantSystem.Tests
{
    [TestFixture]
    public class RestaurantServiceTests
    {
        private RestaurantService service;

        // тестови имена на файлове
        private readonly string ingFile = "ingredients.json";
        private readonly string menuFile = "menu.json";
        private readonly string orderFile = "orders.json";

        [SetUp]
        public void Setup()
        {
            // изчистваме всички файлове преди всеки тест
            if (File.Exists(ingFile)) File.Delete(ingFile);
            if (File.Exists(menuFile)) File.Delete(menuFile);
            if (File.Exists(orderFile)) File.Delete(orderFile);

            // празни JSON файлове (избягваме null reference)
            File.WriteAllText(ingFile, "[]");
            File.WriteAllText(menuFile, "[]");
            File.WriteAllText(orderFile, "[]");

            // рестартираме услугата
            service = new RestaurantService();
        }

        // ================== INGREDIENTS =====================

        [Test]
        public void AddIngredient_ValidData_ShouldAdd()
        {
            
        }

        [Test]
        public void AddIngredient_EmptyName_ShouldThrow()
        {
           
        }

        [Test]
        public void AddIngredient_NegativeQuantity_ShouldThrow()
        {
           
        }

        [Test]
        public void AddIngredient_Duplicate_ShouldThrow()
        {
           
        }

        [Test]
        public void UseIngredient_Valid_ShouldDecreaseQuantity()
        {
           
        }

        [Test]
        public void UseIngredient_MissingIngredient_ShouldThrow()
        {
           
        }

        [Test]
        public void UseIngredient_TooMuch_ShouldThrow()
        {
           
        }

        [Test]
        public void UseIngredient_Negative_ShouldThrow()
        {
            
        }

        // ================== MENU ITEMS =====================

        [Test]
        public void AddMenuItem_Valid_ShouldAdd()
        {
           
        }

        [Test]
        public void AddMenuItem_EmptyName_ShouldThrow()
        {
           
        }

        [Test]
        public void AddMenuItem_InvalidPrice_ShouldThrow()
        {
           
        }

        [Test]
        public void AddIngredientToRecipe_Valid_ShouldAdd()
        {
           
        }

        [Test]
        public void AddIngredientToRecipe_MissingItem_ShouldThrow()
        {
           
        }

        [Test]
        public void AddIngredientToRecipe_NegativeAmount_ShouldThrow()
        {

        }
        // ================== ORDERS =====================

        [Test]
        public void CreateOrder_Valid_ShouldCreateOrder()
        {
            //Arrange
            service.AddIngredient("Cheese", 500);
            service.AddIngredient("Dough", 500);
            service.AddMenuItem("Pizza", 12);

            service.AddIngredientToRecipe("Pizza", "Cheese", 50);
            service.AddIngredientToRecipe("Pizza", "Dough", 100);
            //Act
            int id = service.CreateOrder(new List<string> { "Pizza" });
            //Assert
            Assert.That(id, Is.EqualTo(1));

            var orders = service.GetOrders();
            Assert.That(orders.Count, Is.EqualTo(1));
            Assert.That(orders[0].Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void CreateOrder_Empty_ShouldThrow()
        {
            
        }

        [Test]
        public void CreateOrder_MissingMenuItem_ShouldThrow()
        {
           
        }

        [Test]
        public void CreateOrder_NotEnoughIngredients_ShouldThrow()
        {
            
        }

        [Test]
        public void PayOrder_Valid_ShouldSetPaid()
        {
           
        }

        [Test]
        public void PayOrder_Missing_ShouldThrow()
        {
           
        }

        [Test]
        public void PayOrder_Twice_ShouldThrow()
        {
        }
    }
}
