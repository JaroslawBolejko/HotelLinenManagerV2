using System.Collections.Generic;

namespace BlazorApp.Models
{
    public class Warehause
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }
        public List<HotelLinen> HotelLinen { get; set; }
    }
}
