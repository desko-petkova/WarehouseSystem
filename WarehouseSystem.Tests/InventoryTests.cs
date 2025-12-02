using NUnit.Framework;
using WarehouseSystem.Models;
using WarehouseSystem.Services;

namespace WarehouseSystem.Tests
{
    [TestFixture]
    public class InventoryTests
    {
        private InventorySystem service;
        private string testFile = "inventory.json";

        [SetUp]
        public void Setup()
        {
           
            if (File.Exists(testFile))
                File.Delete(testFile);


            service = new InventorySystem();
        }

        //TOTAL QUANTITY
        [Test]
        public void TotalQuantity_ShouldReturnCorrectSum()
        {
            //Arrange
            service.AddProduct("Bread", 1.20, 10, "M", "D");
            service.AddProduct("Milk", 2.20, 5, "M", "D");
            //Act
            double total = service.TotalQuantity();
            //Assert
            Assert.That(total, Is.EqualTo(15));
        }

        //AVERAGE PRICE
        [Test]
        public void AveragePrice_ShouldReturnCorrectValue()
        {
            //Arrange
            service.AddProduct("P1", 10, 1, "M", "D");
            service.AddProduct("P2", 20, 1, "M", "D");
            //Act
            double avg = service.AveragePrice();
            //Assert
            Assert.That(avg, Is.EqualTo(15));
        }
        [Test]
        public void AveragePrice_NoProducts_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => service.AveragePrice());


        }

        //MOST EXPENSIVE
        [Test]
        public void MostExpensive_ShouldReturnCorrectProduct()
        {
            //Arrange
            service.AddProduct("Cheap", 1, 10, "M", "D");
            service.AddProduct("Expensive", 10, 10, "M", "D");
            //Act
            Product p = service.MostExpensive();
            //Assert
            Assert.That(p.Name, Is.EqualTo("Expensive"));
        }


        [Test]
        public void MostExpensive_NoProducts_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => service.MostExpensive());

        }

        // CHEAPEST
        [Test]
        public void Cheapest_ShouldReturnCorrectProduct()
        {
            service.AddProduct("Cheap", 1, 10, "M", "D");
            service.AddProduct("Expensive", 10, 10, "M", "D");

            Product p = service.Cheapest();

            Assert.That(p.Name, Is.EqualTo("Cheap"));
        }

        [Test]
        public void Cheapest_NoProducts_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => service.Cheapest());

        }

        //AddProduct
        [Test]
        public void AddProduct_ValidData_ShouldAdd()
        {
            // Act
            service.AddProduct("Bread", 1.20, 10, "BakerCo", "Distrib");

            // Assert
            Assert.That(service.GetAll().Count, Is.EqualTo(1));
            Assert.That(service.GetAll()[0].Name, Is.EqualTo("Bread"));
        }

        [Test]
        public void AddProduct_InvalidData_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => service.AddProduct("Tea", 0, 12, "M", "D"));
            Assert.Throws<ArgumentException>(() => service.AddProduct("T", 2, 1, "M", "D"));
            Assert.Throws<ArgumentException>(() => service.AddProduct("Tea", 4, -12, "M", "D"));
            Assert.Throws<ArgumentException>(() => service.AddProduct("Tea", 3, 12, "", "D"));
            Assert.Throws<ArgumentException>(() => service.AddProduct("Tea", 3, 12, "M", ""));
        }

        //UpdateQuantity
        [Test]
        public void UpdateQuantity_Valid_ShouldUpdate()
        {
            service.AddProduct("Water", 1.0, 20, "Prod", "Dist");

            // Act
            service.UpdateQuantity("Water", 50);

            var list = service.GetAll();
            Assert.That(list[0].Quantity, Is.EqualTo(50));

            // Assert
            Assert.That(service.GetAll()[0].Quantity, Is.EqualTo(50));
        }

        [Test]
        public void UpdateQuantity_NegativeProductNotFound_ShouldThrow()
        {
            service.AddProduct("Fish", 24.6, 10, "M", "D");

            Assert.Throws<ArgumentException>(() => service.UpdateQuantity("Fish", -5));


        }

        [Test]
        public void UpdateQuantity_ProductNotFound_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => service.UpdateQuantity("NonExisting", 10));

        }

        //IsAvailable
        [Test]
        public void IsAvailable_WhenQuantityPositive_ShouldBeTrue()
        {
            service.AddProduct("Juice", 2.00, 5, "M", "D");

            bool result = service.IsAvailable("Juice");

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsAvailable_WhenZero_ShouldBeFalse()
        {
            service.AddProduct("Coffee", 3.50, 0, "M", "D");

            bool result = service.IsAvailable("Coffee");

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsAvailable_ProductNotFound_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => service.IsAvailable("Ghost"));
        }
    }
}
