using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses
{
    public class CreateWarehauseRequest : RequestBase, IRequest<CreateWarehauseResponse>
    {
        public WarehauseType WarehauseType { get; set; }

        public string Name { get; set; }
        public int? WarehauseNumber { get; set; }

        public int? CompanyId { get; set; }

        public List<WarehauseDetail> WarehauseDetails { get; set; }

    }
}
