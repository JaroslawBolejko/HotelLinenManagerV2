using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class WarehauseDetail : EntityBase
    {
        [Required]
        public int HotelLinenId { get; set; }
        [Required]
        public int WarehauseId { get; set; }
        [Required]
        public ushort Amount { get; set; }
        public HotelLinen HotelLinen { get; set; }
        public Warehause Warehause { get; set; }

    }
}
