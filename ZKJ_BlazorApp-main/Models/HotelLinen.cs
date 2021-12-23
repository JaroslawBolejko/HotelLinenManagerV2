using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public enum Type
    {

        //Cover = 1,
        Poszwa = 1,
        //Sheet = 2,
        Prześcieradło = 2,
        //Pillowcase = 3,
        Poszewka = 3,
        //Underlay = 4,
        Podkałd = 4,
        //Towel = 5,
        Ręcznik = 5,
        //Duvel = 6,
        Kołdra = 6,
        //Pillow = 7,
        Poduszka = 7,
        //Coverlet = 8,
        Kapa = 8,
        //Blanket = 9,
        Koc = 9,
        //Drape = 10,
        Zasłona = 10,
        //Curtain = 11,
        Firanka = 11,
        //Cloth = 12,
        Obrus = 12,
        //Napkin = 13
        Serwetka = 13

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
        [Range(0,10000)]
        public int Amount { get; set; }
        [Required]
        public Type TypeName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Size { get; set; }
        [Range(0,100)]
        public double Weight { get; set; }
        public bool IsUsed { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int WarehauseId {get;set;}
        public Warehause Warehause { get; set; }
        public IEnumerable<WarehauseDetail> WarehauseDetails { get; set; }
        public IEnumerable<PriceListDetail> PriceListDetails { get; set; }

    }
}
