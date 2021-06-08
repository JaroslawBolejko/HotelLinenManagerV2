using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinens;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.HotelLinens
{
    public class GetHotelLinenByIdHandler : IRequestHandler<GetHotelLinenByIdRequest, GetHotelLinenByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetHotelLinenByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetHotelLinenByIdResponse> Handle(GetHotelLinenByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetHotelLinenQuery()
            {
                Id = request.Id
            };
            var hotelLinen = await this.queryExecutor.Execute(query);
            if (hotelLinen == null)
            {
                return new GetHotelLinenByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedHotelLinen = this.mapper.Map<HotelLinen>(hotelLinen);
            var response = new GetHotelLinenByIdResponse()
            {
                Data = mappedHotelLinen
            };
            return response;
        }
    }
}
