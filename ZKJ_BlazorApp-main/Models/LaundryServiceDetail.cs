using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public string HotelLinenName { get; set; }
        public string Color { get; set; }
    }
}
