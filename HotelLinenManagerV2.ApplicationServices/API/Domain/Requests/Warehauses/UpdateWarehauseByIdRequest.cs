using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses
{
    public class UpdateWarehauseByIdRequest : RequestBase, IRequest<UpdateWarehauseByIdResponse>
    {

        public int id;
        public WarehauseType WarehauseType { get; set; }

        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }

        public int CompanyId { get; set; }
    }
}
