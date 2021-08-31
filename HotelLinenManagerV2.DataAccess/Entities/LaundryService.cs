using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "date")]
        public DateTime RecievedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? IssuedDate { get; set; }
        public bool IsFinished { get; set; }
        public List<LaundryServiceDetail> LaundryServiceDetails { get; set; }
        public Company Company { get; set; }
    }
}
