using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        public List<Company> Company { get; set; }
        public List<HotelLinen> HotelLinen { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public DateTime DocumentDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string DocumentName { get; set; }
        [Required]
        [MaxLength(50)]
        public string DocumentNumber { get; set; }


    }
}
