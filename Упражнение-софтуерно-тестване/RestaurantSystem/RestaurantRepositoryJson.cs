using RestaurantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class RestaurantRepositoryJson
    {
        private const string IngredientsPath = "ingredients.json";
        private const string MenuPath = "menu.json";
        private const string OrdersPath = "orders.json";

        public List<Ingredient> LoadIngredients()
        {
            if (!File.Exists(IngredientsPath))
                return new List<Ingredient>();

            return JsonSerializer.Deserialize<List<Ingredient>>(File.ReadAllText(IngredientsPath))
                ?? new List<Ingredient>();
        }

        public List<MenuItem> LoadMenu()
        {
            if (!File.Exists(MenuPath))
                return new List<MenuItem>();

            return JsonSerializer.Deserialize<List<MenuItem>>(File.ReadAllText(MenuPath))
                ?? new List<MenuItem>();
        }

        public List<Order> LoadOrders()
        {
            if (!File.Exists(OrdersPath))
                return new List<Order>();

            return JsonSerializer.Deserialize<List<Order>>(File.ReadAllText(OrdersPath))
                ?? new List<Order>();
        }

        public void SaveIngredients(List<Ingredient> data) =>
            File.WriteAllText(IngredientsPath, JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));

        public void SaveMenu(List<MenuItem> data) =>
            File.WriteAllText(MenuPath, JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));

        public void SaveOrders(List<Order> data) =>
            File.WriteAllText(OrdersPath, JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
    }
}

