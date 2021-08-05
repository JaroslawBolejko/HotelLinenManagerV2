using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum WarehauseType : byte
    {
        CleanLinenWarehause = 0,
        DirtyLinenWarehause = 1,
        Room = 2

    }

    public class Warehause : EntityBase
    {
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }

        [Required]
        public WarehauseType WarehauseType { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }


    }
}
