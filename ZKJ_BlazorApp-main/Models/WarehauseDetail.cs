using BlazorApp.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class WarehauseDetail
    {
        public int Id { get; set; }
        public int HotelLinenId { get; set; }
        public int WarehauseId { get; set; }
        [Range(0,10000)]
        public int Amount { get; set; }
        public string HotelLinenName { get; set; }
        public string Color { get; set; }
        public Type HotelLinenType { get; set; }

    }
}
