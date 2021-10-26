using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using MediatR;
using System;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists
{
    public class UpdatePriceListByIdRequest : RequestBase,IRequest<UpdatePriceListByIdResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int LaundryId { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
