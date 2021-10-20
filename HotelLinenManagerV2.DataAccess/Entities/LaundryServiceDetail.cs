using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class LaundryServiceDetail : EntityBase

    {
        [Required]
        public int LaundryServiceId { get; set; }
        [Required]
        public int HotelLinenId { get; set; }
        [Required]
        [Range(0, 10000)]
        public int Amount { get; set; }
        [Required]
        public decimal PricePerKg { get; set; }
        [Required]
        public double TotalWeight { get; set; }
        [Required]
        public int TaxValue { get; set; }
        public LaundryService LaundryService { get; set; }
        public HotelLinen HotelLinen { get; set; }
    }
}
