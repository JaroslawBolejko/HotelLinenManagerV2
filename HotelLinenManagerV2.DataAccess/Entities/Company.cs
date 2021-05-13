using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum CompanyType
    {
        Hotel,
        Laundry
    }
    public class Company : EntityBase
    {
        [Required]
        public CompanyType Type { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [StringLength(12)]
        public string TaxNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required]
        [MaxLength(10)]
        public string Number { get; set; }
        [Required]
        [StringLength(6)]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        public List<Warehause> Warehauses { get; set; }
        public List<Invoice> Invoices { get; set; } 
        public List<LaundryService> LaundryServices { get; set; }


    }
}
