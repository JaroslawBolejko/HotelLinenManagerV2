using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class LaundryService
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LaundryId {get;set;}
        public string Name { get; set; }
        public string Number { get; set; }
        [DataType(DataType.Date)]
        public DateTime RecievedDate { get; set; }
        public DateTime? IssuedDate { get; set; }
        public bool IsFinished { get; set; }
        public List<LaundryServiceDetail> LaundryServiceDetails { get; set; }
        public Company Company { get; set; }
        public Company Laundry { get; set; }
    }
}
