﻿using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class CreateHotelLinenRequest : IRequest<CreateHotelLinenResponse>
    {
        public string NameWithShortDescription { get; set; }
        public string Color { get; set; }
        public int HotelLinenTypeId { get; set; }
        public ushort Amount { get; set; }
        public int? WarehauseId { get; set; }

    }
}
