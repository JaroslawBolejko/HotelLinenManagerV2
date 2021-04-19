using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class HotelLinen : EntityBase
    {



        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [MaxLength(250)]
        public string Type { get; set; }
        [MaxLength(250)]
        public string Size { get; set; }
        [MaxLength(250)]
        public string Color { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public double Weight { get; set; }
    }
}
