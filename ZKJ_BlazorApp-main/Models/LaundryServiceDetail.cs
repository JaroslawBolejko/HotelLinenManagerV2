using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class LaundryServiceDetail
    {
        public int Id { get; set; }
        [Required]
        public int LaundryServiceId { get; set; }
        [Required]
        public int HotelLinenId { get; set; }
        [Required]
        [Range(0, 10000)]
        public int Amount { get; set; }
        public Type HotelLinenType { get; set; }
        public string HotelLinenName { get; set; }
        public string Color { get; set; }
        public decimal PricePerKg { get; set; }
        public double TotalWeight { get; set; }
        public int TaxValue { get; set; }
    }
}
