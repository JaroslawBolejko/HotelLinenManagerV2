using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public enum WarehauseType
    {
        [Display(Name = "Magazyn Czystej Bielizny")]
        Magazyn_Czystej_Bielizny = 0,
        [Display(Name = "Magazyn Brudnej Bielizny")]
        Magazyn_Brudnej_Bielizny = 1,
        [Display(Name = "Inne Pomieszczenie")]
        Inne_Pomieszczenie = 2
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
        public IEnumerable<WarehauseDetail> WarehauseDetails { get; set; }


    }
}
