using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using MediatR;
using System;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices
{
    public class CreateLaundryRequest : RequestBase,IRequest<CreateLaundryResponse>
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime RecievedDate { get; set; }
        public DateTime IssuedDate { get; set; }
    }
}
