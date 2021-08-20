using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using MediatR;
using System;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices
{
    public class UpdateLaundryRequest : RequestBase,IRequest<UpdateLaundryResponse>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime RecievedDate { get; set; }
        public DateTime IssuedDate { get; set; }
        public bool IsFinished { get; set; }

    }
}
