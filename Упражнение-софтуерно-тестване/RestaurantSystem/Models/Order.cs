using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<MenuItem> Items { get; set; } = new();
        public bool IsPaid { get; set; }

        public double Total => Items.Sum(i => i.Price);

        public override string ToString()
        {
            return $"Order #{Id} | Items: {Items.Count} | Total: {Total:F2} lv | {(IsPaid ? "PAID" : "UNPAID")}";
        }
    }
}
