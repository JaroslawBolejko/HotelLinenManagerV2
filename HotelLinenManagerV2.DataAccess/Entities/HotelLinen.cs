using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class HotelLinen : EntityBase
    {
        [Required]
        public int WarehauseId { get; set; }
        public Warehause Warehause { get; set; }
        [Required]
        public int HotelLinenTypeId { get; set; }
        public HotelLinenType HotelLinenType { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameWithShortDescription { get; set; }

        [Required]
        public ushort Amount { get; set; }
    }
}
