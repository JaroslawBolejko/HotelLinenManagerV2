using System;
using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class LaundryService
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime RecievedDate { get; set; }
        public DateTime IssuedDate { get; set; }
        public List<LaundryServiceDetail> LaundryServiceDetails { get; set; }
    }
}
