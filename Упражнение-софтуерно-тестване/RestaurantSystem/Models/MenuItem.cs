using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Models
{
    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Dictionary<string, double> Recipe { get; set; } = new(); // ключ: ingredient → стойност: quantity

        public override string ToString()
        {
            return $"{Name} | {Price:F2} lv";
        }
    }
}
