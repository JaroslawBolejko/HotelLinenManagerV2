using BlazorApp.Helpers;
using System.ComponentModel.DataAnnotations;


namespace BlazorApp.Models
{
    //It is a class to keep some data for a very short time. just to acomplish a task.
    public class Move
    {
        [Required]
        public int WarehauseToMove { get; set; }
        [Required]
        public int HotelLinenToMove { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Wartość nie może być ujemna lub większa od 10000")]
        public int AmountToMove { get; set; }
        public int WarehauseDetailId { get; set; }

        public double TotalServiceWeight { get; set; }
        public decimal TotalServiceTax { get; set; }
        public decimal TotalNetto { get; set; }
        public decimal TotalBrutto { get; set; }
        public decimal SingleBruttoValue { get; set; }


    }
}
