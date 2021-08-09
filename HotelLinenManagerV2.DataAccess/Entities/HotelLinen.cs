using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class HotelLinen : EntityBase
    {

        public List<WarehauseDetail> WarehauseDetails { get; set; }

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
        public int CompanyId { get; set; }
        
       

    }
}
