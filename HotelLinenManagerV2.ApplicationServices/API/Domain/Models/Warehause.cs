﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
   public  class Warehause
    {
        //public WarehauseType WarehauseType { get; set; }
        public HotelLinen HotelLinen { get; set; }
        public int HotelLinenAmount { get; set; }
        public int CompanyId { get; set; }
      //  public Company Company { get; set; }
    }
}
