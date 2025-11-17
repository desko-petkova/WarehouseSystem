using WarehouseSystem.Services;
using WarehouseSystem.Views;

namespace WarehouseSystem.Controllers
{
    public class InventoryController
    {
        private readonly InventorySystem system;
        private readonly InventoryView view;

        public InventoryController()
        {
            system = new InventorySystem();
            view = new InventoryView();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                view.ShowMenu();
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": AddProduct(); break;
                        case "2": ShowAll(); break;
                        case "3": UpdateQuantity(); break;
                        case "4": CheckAvailability(); break;
                        case "5": ShowTotalQuantity(); break;
                        case "6": ShowAveragePrice(); break;
                        case "7": ShowMostExpensive(); break;
                        case "8": ShowCheapest(); break;
                        case "x": return;
                        default:
                            view.ShowMessage("Invalid option");
                            view.Pause();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    view.ShowMessage("Error: " + ex.Message);
                    view.Pause();
                }
            }
        }

        private void AddProduct()
        {
            string name = view.ReadInput("Name: ");
            double price = double.Parse(view.ReadInput("Price: "));
            double quantity = double.Parse(view.ReadInput("Quantity: "));
            string m = view.ReadInput("Manufacturer: ");
            string d = view.ReadInput("Distributor: ");

            system.AddProduct(name, price, quantity, m, d);
            view.ShowMessage("Added successfully!");
            view.Pause();
        }

        private void ShowAll()
        {
            view.ShowProducts(system.GetAll());
            view.Pause();
        }

        private void UpdateQuantity()
        {
            string name = view.ReadInput("Name: ");
            double q = double.Parse(view.ReadInput("New quantity: "));

            system.UpdateQuantity(name, q);

            view.ShowMessage("Updated!");
            view.Pause();
        }

        private void CheckAvailability()
        {
            string name = view.ReadInput("Name: ");

            bool result = system.IsAvailable(name);
            view.ShowMessage("Available: " + result);
            view.Pause();
        }

        private void ShowTotalQuantity()
        {
            double total = system.TotalQuantity();
            view.ShowMessage($"Total quantity of all products: {total}");
            view.Pause();
        }
        private void ShowAveragePrice()
        {
            try
            {
                double avg = system.AveragePrice();
                view.ShowMessage($"Average product price: {avg} лв");
            }
            catch (Exception ex)
            {
                view.ShowMessage("Error: " + ex.Message);
            }

            view.Pause();
        }
        private void ShowMostExpensive()
        {
            try
            {
                var p = system.MostExpensive();
                view.ShowMessage("Most expensive product:");
                view.ShowMessage(p.ToString());
            }
            catch (Exception ex)
            {
                view.ShowMessage("Error: " + ex.Message);
            }

            view.Pause();
        }
        private void ShowCheapest()
        {
            try
            {
                var p = system.Cheapest();
                view.ShowMessage("Cheapest product:");
                view.ShowMessage(p.ToString());
            }
            catch (Exception ex)
            {
                view.ShowMessage("Error: " + ex.Message);
            }

            view.Pause();
        }
    }
}
