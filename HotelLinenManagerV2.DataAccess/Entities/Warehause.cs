using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum WarehauseType : byte
    {
        Magazyn_Czystej_Bielizny = 0,
        Magazyn_Brudnej_Bielizny = 1,
        Inne_Pomieszczenie = 2

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
