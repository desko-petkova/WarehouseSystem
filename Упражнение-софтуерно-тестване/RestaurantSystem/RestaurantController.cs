using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class RestaurantController
    {
        private readonly RestaurantService service = new();
        private readonly RestaurantView view = new();

        public void Run()
        {
            while (true)
            {
                view.Menu();
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": AddIngredient(); break;
                        case "2": UseIngredient(); break;
                        case "3": AddMenuItem(); break;
                        case "4": AddIngredientToRecipe(); break;
                        case "5": CreateOrder(); break;
                        case "6": PayOrder(); break;
                        case "7": ShowIngredients(); break;
                        case "8": ShowMenu(); break;
                        case "9": ShowOrders(); break;
                        case "x": return;
                        default:
                            view.Message("Invalid choice.");
                            break;
                    }
                    view.Pause();
                }
                catch (Exception ex)
                {
                    view.Message("Error: " + ex.Message);
                    view.Pause();
                }
            }
        }

        private void AddIngredient()
        {
            string name = view.Input("Ingredient name: ");
            double qty = double.Parse(view.Input("Quantity: "));
            service.AddIngredient(name, qty);
            view.Message("Added.");
        }

        private void UseIngredient()
        {
            string name = view.Input("Ingredient: ");
            double qty = double.Parse(view.Input("Amount: "));
            service.UseIngredient(name, qty);
            view.Message("Used.");
        }

        private void AddMenuItem()
        {
            string name = view.Input("New item name: ");
            double price = double.Parse(view.Input("Price: "));
            service.AddMenuItem(name, price);
            view.Message("Added.");
        }

        private void AddIngredientToRecipe()
        {
            string mi = view.Input("Menu item: ");
            string ing = view.Input("Ingredient: ");
            double qty = double.Parse(view.Input("Amount: "));

            service.AddIngredientToRecipe(mi, ing, qty);
            view.Message("Ingredient added to recipe.");
        }

        private void CreateOrder()
        {
            var items = new List<string>();
            while (true)
            {
                string name = view.Input("Add item (blank to finish): ");
                if (string.IsNullOrWhiteSpace(name)) break;
                items.Add(name);
            }

            int id = service.CreateOrder(items);
            view.Message($"Order {id} created!");
        }

        private void PayOrder()
        {
            int id = int.Parse(view.Input("Order ID: "));
            service.PayOrder(id);
            view.Message("Paid.");
        }

        private void ShowIngredients()
        {
            foreach (var i in service.GetIngredients())
                view.Message($"{i.Name} → {i.Quantity}g");
        }

        private void ShowMenu()
        {
            foreach (var m in service.GetMenu())
                view.Message(m.ToString());
        }

        private void ShowOrders()
        {
            foreach (var o in service.GetOrders())
                view.Message(o.ToString());
        }
    }
}
