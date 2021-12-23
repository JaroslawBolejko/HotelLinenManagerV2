using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public enum CompanyType
    {
        Hotel = 0,
        Laundry = 1
    }
    public class Company
    {
        public int Id { get; set; }
        public CompanyType Type { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string TaxNumber { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string EMail { get; set; }
        public string TelefonNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public List<PriceList> CompanyPriceLists { get; set; }
        public List<PriceList> LaundryPriceLists { get; set; }
        public List<RelatedCompany> RelatedCompanies { get; set; }


    }
}
