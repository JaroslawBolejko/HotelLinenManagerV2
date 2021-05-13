using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public WarehauseType WarehauseType { get; set; }
        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }

    }
}
