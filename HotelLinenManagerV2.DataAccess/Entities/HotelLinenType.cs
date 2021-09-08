using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum Type : byte
    {
        
        DuvelCover = 1,
        Sheet = 2,
        PillowCase = 3,
        Underlay = 4,
        Towel = 5,
        FootTowel = 6,
        Duvel = 7,
        Pillow = 8,
        Coverlet = 9,
        Blanket = 10,
        Drape = 11,
        Curtain = 12,
        TableCloth = 13,
        Napkin = 14
    }
    public class HotelLinenType : EntityBase
    {
        [Required]
        [MaxLength(80)]
        public Type TypeName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Size { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public double Weight { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public decimal PricePerKg { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public decimal Tax { get; set; }

        public List<HotelLinen> HotelLinens { get; set; }
    }
}

