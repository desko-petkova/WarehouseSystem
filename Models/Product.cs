namespace WarehouseSystem.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string Distributor { get; set; }

        public override string ToString()
        {
            return $"{Name} | {Price} лв | {Quantity} бр | {Manufacturer} | {Distributor}";
        }
    }
}
