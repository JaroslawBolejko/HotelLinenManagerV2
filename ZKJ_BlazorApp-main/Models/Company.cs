using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BlazorApp.Models
{
    public enum CompanyType
    {
        Hotel = 1,
        Laundry = 2
    }
    public class Company
    {
        public int Id { get; set; }
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
        public string EMail { get; set; }
        [MaxLength(20)]
        public string TelefonNumber { get; set; }
        public List<PriceList> CompanyPriceLists { get; set; }

        public List<PriceList> LaundryPriceLists { get; set; }
        

    }
}
