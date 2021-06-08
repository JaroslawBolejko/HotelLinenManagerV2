using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum Type : byte
    {
        //Zmień na angielski
        Poszwa = 1,
        Prześcieradło = 2,
        Poszewka = 3,
        Podkład = 4,
        RęcznikDuży = 5,
        RęcznikMały = 6,
        Stopka = 7,
        Kołdra = 8,
        Poduszka = 9,
        Jasiek = 10,
        Kapa = 11,
        Koc = 12,
        Zasłona = 13,
        Firanka = 14,
        ObrusDuży = 15,
        ObrusŚredni = 16,
        ObrusMały = 17,
        Serwetki = 18

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

