using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
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
    public class HotelLinen
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }
        public int Amount { get; set; }
        [Required]
        public Type TypeName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Size { get; set; }
        [Range(0,100)]
        public double Weight { get; set; }
        [Range(0,1000)]
        public decimal PricePerKg { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int WarehauseId {get;set;}
        public Warehause Warehause { get; set; }
        public IEnumerable<WarehauseDetail> WarehauseDetails { get; set; }

    }
}
