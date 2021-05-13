using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public  class LaundryService : EntityBase
    {
        public List<Company> Companies { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }
        [Required]
        public DateTime RecievedDate { get; set;}
        public DateTime IssuedDate { get; set; }

    }
}
