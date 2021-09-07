using System;
using System.Collections.Generic;

namespace BlazorApp.Models
{
    public class HotelLinenType
    {
        public int Id { get; set; }
        public Type TypeName { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal Tax { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }
    }
}
