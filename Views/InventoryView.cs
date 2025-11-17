using WarehouseSystem.Models;

namespace WarehouseSystem.Views
{
    public class InventoryView
    {
        public void ShowMenu()
        {
            Console.WriteLine("==== INVENTORY SYSTEM ====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Show All");
            Console.WriteLine("3. Update Quantity");
            Console.WriteLine("4. Check Availability");
            Console.WriteLine("5. Total Quantity");
            Console.WriteLine("6. Average Price");
            Console.WriteLine("7. Most Expensive Product");
            Console.WriteLine("8. Cheapest Product");
            Console.WriteLine("X. Exit");
            Console.Write("Choice: ");
        }

        public void ShowProducts(List<Product> products)
        {
            foreach (var p in products)
                Console.WriteLine(p);
        }

        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public string ReadInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void Pause()
        {
            Console.WriteLine("Press ENTER...");
            Console.ReadLine();
        }

    }
}
