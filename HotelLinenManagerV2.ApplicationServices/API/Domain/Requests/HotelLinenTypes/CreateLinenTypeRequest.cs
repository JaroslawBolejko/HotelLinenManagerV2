using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinenTypes;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinenTypes
{
    public class CreateLinenTypeRequest : RequestBase,IRequest<CreateLinenTypeResponse>
    {
        public Type? TypeName { get; set; }
        public string Size { get; set; }
        public double? Weight { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal Tax { get; set; }
    }
}
