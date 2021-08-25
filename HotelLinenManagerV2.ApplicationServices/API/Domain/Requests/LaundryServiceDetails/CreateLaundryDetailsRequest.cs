﻿using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServiceDetails;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails
{
    public class CreateLaundryDetailsRequest : RequestBase,IRequest<CreateLaundryDetailsResponse>
    {
        public int LaundryServiceId { get; set; }
        public int HotelLinenId { get; set; }
        public int Amount { get; set; }
       
    }
}