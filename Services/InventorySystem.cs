using WarehouseSystem.Data;
using WarehouseSystem.Models;

namespace WarehouseSystem.Services
{
    public class InventorySystem
    {

        private readonly InventoryRepository repo;
        private List<Product> _products;

        public InventorySystem()
        {
            repo = new InventoryRepository();
            _products = repo.Load();
        }

        public void AddProduct(string name, double price, double quantity,
                               string manufacturer, string distributor)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
                throw new ArgumentException("Invalid product name.");

            if (price <= 0)
                throw new ArgumentException("Price must be positive.");

            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            if (string.IsNullOrWhiteSpace(manufacturer))
                throw new ArgumentException("Manufacturer required.");

            if (string.IsNullOrWhiteSpace(distributor))
                throw new ArgumentException("Distributor required.");

            var product = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Manufacturer = manufacturer,
                Distributor = distributor
            };

            _products.Add(product);
            repo.Save(_products);
        }

        public void UpdateQuantity(string name, double newQuantity)
        {

            var product = _products.FirstOrDefault(p =>
    p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                ?? throw new ArgumentException("Product not found.");

            if (newQuantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            product.Quantity = newQuantity;
            repo.Save(_products);
        }

        public bool IsAvailable(string name)
        {
            var product = _products.FirstOrDefault(p => p.Name == name)
               ?? throw new ArgumentException("Product not found.");

            return product.Quantity > 0;
        }

        public double TotalQuantity() => _products.Sum(x => x.Quantity);

        public double AveragePrice()
        {
            if (_products.Count == 0)
                throw new InvalidOperationException("No products.");

            return Math.Round(_products.Average(p => p.Price), 2);
        }

        public Product MostExpensive()
        {
            if (_products.Count == 0)
                throw new InvalidOperationException("No products.");

            return _products.OrderByDescending(p => p.Price).First();
        }

        public Product Cheapest()
        {
            if (_products.Count == 0)
                throw new InvalidOperationException("No products.");

            return _products.OrderBy(p => p.Price).First();
        }

        public List<Product> GetAll() => _products;
    }
}

