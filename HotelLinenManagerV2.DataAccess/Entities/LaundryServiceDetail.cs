using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class LaundryServiceDetail : EntityBase

    {
        
        public int LaundryServiceId { get; set; }
        [Required]
        public int HotelLinenId { get; set; }
        [Required]
        [Range(0, 10000)]
        public int Amount { get; set; }
        public double TotalWeight { get; set; }
        public LaundryService LaundryService { get; set; }
        public HotelLinen HotelLinen { get; set; }
    }
}
