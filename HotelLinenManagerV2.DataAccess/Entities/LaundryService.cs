using System;
using System.Collections.Generic;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class LaundryService : EntityBase
    {
        public int CompanyId { get; set; }
        public DateTime RecievedDate { get; set; }
        public DateTime IssuedDate { get; set; }
        public List<LaundryServiceDetail> LaundryServiceDetails { get; set; }
        public Company Company { get; set; }
    }
}
