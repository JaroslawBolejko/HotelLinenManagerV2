using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.WarehauseDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.WarehauseDetails;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.WarehauseDetails
{
    public class GetWarehauseDetailByIdHandler : IRequestHandler<GetDetailsByIdRequest, GetDetailsByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryexecutor;

        public GetWarehauseDetailByIdHandler(IMapper mapper, IQueryExecutor queryexecutor)
        {
            this.mapper = mapper;
            this.queryexecutor = queryexecutor;
        }

        public async Task<GetDetailsByIdResponse> Handle(GetDetailsByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetWarehauseDetailQuery()
            {
                Id = request.Id
            };
            var detail = await this.queryexecutor.Execute(query);
            if (detail == null)
            {
                return new GetDetailsByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDetail = this.mapper.Map<WarehauseDetail>(detail);
            return new GetDetailsByIdResponse()
            {
                Data = mappedDetail
            };
        }
    }
}
