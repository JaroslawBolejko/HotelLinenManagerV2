using HotelLinenManagerV2.DataAccess.Entities;
using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public CompanyType Type { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string TelefonNumber { get; set; }
        //    public List<Warehause> Warehauses { get; set; }
        //    public List<Invoice> Invoices { get; set; }
        //    public List<LaundryService> LaundryServices { get; set; }
    }
}
