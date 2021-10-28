using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public enum CompanyType
    {
        Hotel=1,
        Laundry=2
    }
    public class Company : EntityBase
    {
        [Required]
        public CompanyType Type { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string TaxNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required]
        [MaxLength(10)]
        public string Number { get; set; }
        public string ApartmentNumber { get; set; }
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
        public List<User> Users { get; set; }
        [InverseProperty("Company")]
        public virtual List<LaundryService> CompanyLaundryServices { get; set; }
        [InverseProperty("Laundry")]
        public virtual List<LaundryService> LaundryLaundryServices { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }

        [InverseProperty("Company")]
        public virtual List<PriceList> CompanyPriceLists { get; set; }
        [InverseProperty("Laundry")]
        public virtual List<PriceList> LaundryPriceLists { get; set; }

        [InverseProperty("Company")]
        public virtual List<RelatedCompany> Companies { get; set; }
        [InverseProperty("Laundry")]
        public virtual List<RelatedCompany> Laundries { get; set; }


    }
}
