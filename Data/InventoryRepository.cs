using System.Text.Json;
using WarehouseSystem.Models;

namespace WarehouseSystem.Data
{
    public class InventoryRepository
    {
        private readonly string filePath = "inventory.json";

        public List<Product> Load()
        {
            if (!File.Exists(filePath))
                return new List<Product>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public void Save(List<Product> products)
        {
            string json = JsonSerializer.Serialize(products, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }
    }
}
