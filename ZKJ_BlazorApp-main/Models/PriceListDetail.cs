using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class PriceListDetail
    {
        public int Id { get; set; }
        [Required]
        [Range(1,1000)]
        public decimal PricePerKg { get; set; }
        [Required]
        [Range(1, 100)]
        public int TaxValue { get; set; }
        public int PriceListId { get; set; }
        public Type LinenType { get; set; }
        public PriceList PriceList { get; set; }
    }
}
