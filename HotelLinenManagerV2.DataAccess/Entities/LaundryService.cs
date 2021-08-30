using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class LaundryService : EntityBase
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(150)]
        public string Number { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RecievedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? IssuedDate { get; set; }
        public bool IsFinished { get; set; }
        public List<LaundryServiceDetail> LaundryServiceDetails { get; set; }
        public Company Company { get; set; }
    }
}
