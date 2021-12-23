using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public enum WarehauseType : byte
    {
   
        //Clean_Linen_Warehause = 0,
        [Display(Name = "Magazyn Czystej Bielizny")]
        Magazyn_Czystej_Pocieli = 0,
        //Dirty_Linen_Warehause = 1,
        [Display(Name = "Magazyn Brudnej Bielizny")]
        Magazyn_Brudnej_Pościeli = 1,
        //Other_room = 2
        [Display(Name = "Inne Pomieszczenie")]
        Inne_pomieszczenie = 2
    }
    public class Warehause
    {
        public int Id { get; set; }
        [Required]
        public WarehauseType WarehauseType { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public List<WarehauseDetail> WarehauseDetails { get; set; }


    }
}
