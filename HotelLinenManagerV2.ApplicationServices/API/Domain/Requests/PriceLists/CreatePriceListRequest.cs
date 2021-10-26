﻿using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using MediatR;
using System;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists
{
    public class CreatePriceListRequest : RequestBase,IRequest<CreatePriceListResponse>
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int LaundryId { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
