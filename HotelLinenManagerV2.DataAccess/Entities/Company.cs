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
        [MaxLength(15)]
        public string TaxNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required]
        [MaxLength(10)]
        public string Number { get; set; }
        public ushort ApartmentNumber { get; set; }
        [Required]
        [StringLength(6)]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string EMail {get;set;}
        [MaxLength(20)]
        public string TelefonNumber { get; set;}

        public List<Warehause> Warehauses { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<LaundryService> LaundryServices { get; set; }


    }
}
