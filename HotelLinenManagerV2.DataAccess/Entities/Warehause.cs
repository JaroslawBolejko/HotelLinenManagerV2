using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum WarehauseType: byte
    {
        CleanLinenWarehause,
        DirtyLinenWarehause,
        Room

    }
  
    public class Warehause : EntityBase
    {
        [Required]
        public WarehauseType WarehauseType { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }

    }
}
