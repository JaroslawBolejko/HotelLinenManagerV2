﻿namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Models
{
    public class HotelLinen
    {
        public int Id { get; set; }
        public string NameWithShortDescription { get; set; }
        public int HotelLinenTypeId { get; set; }

        //  public int HLBaseQuantity { get; set; }
        //  public List<Warehause> Warehauses { get; set; }

    }
}
