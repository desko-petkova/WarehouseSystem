using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class RestaurantView
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("=== RESTAURANT SYSTEM ===");
            Console.WriteLine("1. Add Ingredient");
            Console.WriteLine("2. Use Ingredient");
            Console.WriteLine("3. Add Menu Item");
            Console.WriteLine("4. Add Ingredient to Recipe");
            Console.WriteLine("5. Create Order");
            Console.WriteLine("6. Pay Order");
            Console.WriteLine("7. Show Ingredients");
            Console.WriteLine("8. Show Menu");
            Console.WriteLine("9. Show Orders");
            Console.WriteLine("X. Exit");
            Console.Write("Choice: ");
        }

        public string Input(string label)
        {
            Console.Write(label);
            return Console.ReadLine();
        }

        public void Message(string msg) => Console.WriteLine(msg);

        public void Pause()
        {
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }
    }
}
