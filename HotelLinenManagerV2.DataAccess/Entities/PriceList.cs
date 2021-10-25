﻿using System.Collections.Generic;

namespace HotelLinenManagerV2.DataAccess.Entities
{
    public class PriceList : EntityBase
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int LaundryId { get; set; }
        public decimal PricePerKg { get; set; }
        public int TaxValue { get; set; }
        public List<HotelLinen> HotelLinens { get; set; }
        public Company Laundry { get; set; }
    }
}
