using WarehouseSystem.Controllers;

namespace WarehouseSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryController controller = new InventoryController();
            controller.Run();
        }
    }
}
