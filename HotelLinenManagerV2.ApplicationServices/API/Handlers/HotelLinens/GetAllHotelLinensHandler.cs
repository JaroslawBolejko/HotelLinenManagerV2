using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinens;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.HotelLinens
{
    public class GetAllHotelLinensHandler : IRequestHandler<GetAllHotelLinenRequest, GetAllHotelLinenResponse>
    {
        private readonly IQueryExecutor querExecutor;
        private readonly IMapper mapper;

        public GetAllHotelLinensHandler(IQueryExecutor querExecutor,IMapper mapper)
        {
            this.querExecutor = querExecutor;
            this.mapper = mapper;
        }

        public async Task<GetAllHotelLinenResponse> Handle(GetAllHotelLinenRequest request, CancellationToken cancellationToken)
        {
            var query = new GetHotelLinensQuery() { };
            var hotelLinen = await this.querExecutor.Execute(query);
            var mappedHotelLinen = this.mapper.Map<List<HotelLinen>>(hotelLinen);
            var response = new GetAllHotelLinenResponse()
            {
                Data = mappedHotelLinen
            };
            return response;

            
        }
    }
}
