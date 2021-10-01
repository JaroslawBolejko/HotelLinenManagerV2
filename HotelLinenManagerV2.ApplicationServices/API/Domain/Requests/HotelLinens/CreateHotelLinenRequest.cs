using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class CreateHotelLinenRequest : RequestBase, IRequest<CreateHotelLinenResponse>
    {
        public Type? TypeName { get; set; }
        public string Size { get; set; }
        public double? Weight { get; set; }
        public decimal PricePerKg { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int Amount { get; set; }
        public int CompanyId { get; set; }

    }
}
