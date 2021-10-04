using BlazorApp.Helpers;
using System.ComponentModel.DataAnnotations;


namespace BlazorApp.Models
{
    public class Move
    {
        [Required]
        public int WarehauseToMove { get; set; }
        [Required]
        public int HotelLinenToMove { get; set; }
        [Required]
        [Range(0,10000, ErrorMessage ="Wartość nie może być ujemna lub większa od 10000")]
        public int AmountToMove { get; set; }

        public int WarehauseDetailId { get; set; }
        
        
    }
}
