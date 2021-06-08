using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class HotelLinen : EntityBase
    {
        [Required]
        public List<Warehause> Warehauses { get; set; }
        [Required]
        public int HotelLinenTypeId { get; set; }
        public HotelLinenType HotelLinenType { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameWithShortDescription { get; set; }
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }
        [Required]
        public ushort Amount { get; set; }
        public HLBaseQuantity HLBaseQuantity { get; set; }
        public int? LaundryServiceId { get; set; }
        public LaundryService LaundryService { get; set; }
    }
}
