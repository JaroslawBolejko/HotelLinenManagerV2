using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum Type : byte
    {
        // Aby wyświetlić odzielnie zastosuj https://stackoverflow.com/questions/1101872/how-to-set-space-on-enum/31988435
        DuvelCover = 1,
        Sheet = 2,
        PillowCase = 3,
        Underlay = 4,
        LargeTowel = 5,
        Smalltowel = 6,
        FootTowel = 7,
        Duvel = 8,
        Pillow = 9,
        SmallPillow = 10,
        Coverlet = 11,
        Blanket = 12,
        Drape = 13,
        Curtain = 14,
        LargeTableCloth = 15,
        MediumTableCloth = 16,
        SamllTableCloth = 17,
        Napkin = 18

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

