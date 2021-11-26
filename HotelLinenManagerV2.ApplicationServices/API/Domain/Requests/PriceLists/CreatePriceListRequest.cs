using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists
{
    public class CreatePriceListRequest : RequestBase,IRequest<CreatePriceListResponse>
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int LaundryId { get; set; }
        public int CompanyId { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime CreationDate { get; set; }
        public  List<PriceListDetail> Details { get; set; }
    }
}
