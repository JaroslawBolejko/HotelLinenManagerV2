using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum Type
    {

        Poszwa = 1,
        Prześcieradło = 2,
        Poszewka = 3,
        Podkład = 4,
        Ręcznik = 5,
        Stopka = 6,
        Kołdra = 7,
        Poduszka = 8,
        Kapa = 9,
        Koc = 10,
        Zasłona = 11,
        Firana = 12,
        Obrus = 13,
        Serwetka = 14

    }
    public class HotelLinen : EntityBase
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
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }
        [Required]
        public ushort Amount { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<WarehauseDetail> WarehauseDetails { get; set; }

    }


}
