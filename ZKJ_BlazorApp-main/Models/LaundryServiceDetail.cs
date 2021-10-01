using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class LaundryServiceDetail
    {
        public int Id { get; set; }
        public int LaundryServiceId { get; set; }
        public int HotelLinenId { get; set; }
        public int Amount { get; set; }
        public string HotelLinenName { get; set; }
        public string Color { get; set; }
    }
}
