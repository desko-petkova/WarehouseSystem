using RestaurantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class RestaurantService
    {
        private readonly RestaurantRepositoryJson repo;
        private readonly List<Ingredient> ingredients;
        private readonly List<MenuItem> menu;
        private readonly List<Order> orders;

        public RestaurantService()
        {
            repo = new RestaurantRepositoryJson();
            ingredients = repo.LoadIngredients();
            menu = repo.LoadMenu();
            orders = repo.LoadOrders();
        }

        // ================= INGREDIENTS ==================

        public void AddIngredient(string name, double quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid name.");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            if (ingredients.Any(i => i.Name == name))
                throw new ArgumentException("Ingredient already exists.");

            ingredients.Add(new Ingredient { Name = name, Quantity = quantity });
            repo.SaveIngredients(ingredients);
        }

        public void UseIngredient(string name, double amount)
        {
            var ing = ingredients.FirstOrDefault(i => i.Name == name)
                ?? throw new ArgumentException("Ingredient not found.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be positive.");

            if (amount > ing.Quantity)
                throw new InvalidOperationException("Not enough ingredient.");

            ing.Quantity -= amount;
            repo.SaveIngredients(ingredients);
        }

        // ================= MENU ==================

        public void AddMenuItem(string name, double price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name.");
            if (price <= 0) throw new ArgumentException("Invalid price.");

            menu.Add(new MenuItem { Name = name, Price = price });
            repo.SaveMenu(menu);
        }

        public void AddIngredientToRecipe(string itemName, string ingredient, double amount)
        {
            var mi = menu.FirstOrDefault(m => m.Name == itemName)
                ?? throw new ArgumentException("Menu item not found.");

            if (amount <= 0)
                throw new ArgumentException("Invalid amount.");

            mi.Recipe[ingredient] = amount;
            repo.SaveMenu(menu);
        }

        // ================= ORDERS ==================

        public int CreateOrder(List<string> itemNames)
        {
            if (itemNames == null || !itemNames.Any())
                throw new ArgumentException("Order empty.");

            var items = new List<MenuItem>();

            foreach (var name in itemNames)
            {
                var item = menu.FirstOrDefault(m => m.Name == name)
                    ?? throw new ArgumentException($"Menu item `{name}` not found.");

                // check stock
                foreach (var r in item.Recipe)
                {
                    var ing = ingredients.First(i => i.Name == r.Key);

                    if (ing.Quantity < r.Value)
                        throw new InvalidOperationException($"Not enough {ing.Name}.");
                }

                items.Add(item);
            }

            // reduce stock
            foreach (var m in items)
            {
                foreach (var r in m.Recipe)
                {
                    var ing = ingredients.First(i => i.Name == r.Key);
                    ing.Quantity -= r.Value;
                }
            }

            repo.SaveIngredients(ingredients);

            var order = new Order
            {
                Id = orders.Count + 1,
                Items = items,
                IsPaid = false
            };

            orders.Add(order);
            repo.SaveOrders(orders);

            return order.Id;
        }

        public void PayOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id)
                ?? throw new ArgumentException("Order not found.");

            if (order.IsPaid)
                throw new InvalidOperationException("Already paid.");

            order.IsPaid = true;
            repo.SaveOrders(orders);
        }

        // ================= GETTERS ==================

        public List<Ingredient> GetIngredients() => ingredients;
        public List<MenuItem> GetMenu() => menu;
        public List<Order> GetOrders() => orders;
    }
}
