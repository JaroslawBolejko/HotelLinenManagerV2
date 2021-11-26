using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum WarehauseType : byte
    {

        Clean_Linen_Warehause = 0,
        Dirty_Linen_Warehause = 1,
        Other_room = 2

    }

    public class Warehause : EntityBase
    {
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<WarehauseDetail> WarehauseDetails { get; set; }
        [Required]
        public WarehauseType WarehauseType { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }

    }
}
