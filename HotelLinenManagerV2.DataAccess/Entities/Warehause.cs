using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum WarehauseType : byte
    {
        CleanLinenWarehause,
        DirtyLinenWarehause,
        Room

    }
    public class Warehause : EntityBase
    {
        [Required]
        public WarehauseType WarehauseType { get; set; }
        public int HotelLinenId { get; set; }
        public HotelLinen HotelLinen { get; set; }
        public int HotelLinenAmount { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
