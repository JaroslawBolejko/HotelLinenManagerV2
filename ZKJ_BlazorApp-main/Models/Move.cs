using System.ComponentModel.DataAnnotations;


namespace BlazorApp.Models
{
    public class Move
    {
        public int WarehauseToMove { get; set; }
        public int HotelLinenToMove { get; set; }
        [Range(0,65535)]
        public ushort AmountToMove { get; set; }
       
    }
}
