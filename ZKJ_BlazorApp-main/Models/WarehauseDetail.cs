using BlazorApp.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class WarehauseDetail
    {
        public int Id { get; set; }
        [Required]
        public int HotelLinenId { get; set; }
        [Required]
        public int WarehauseId { get; set; }
        [Required]
        [Range(0,10000)]
        public int Amount { get; set; }
        public string HotelLinenName { get; set; }
        public string Color { get; set; }
        public Type HotelLinenType { get; set; }

    }
}
