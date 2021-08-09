using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Warehauses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Warehauses
{
    public class GetWarehauseByIdHandler : IRequestHandler<GetWarehauseByIdRequest, GetWarehauseByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetWarehauseByIdHandler(IQueryExecutor queryExecutor,IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetWarehauseByIdResponse> Handle(GetWarehauseByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetWarehauseQuery()
            {
                Id = request.WarehauseId
            };
            var getWarehause = await this.queryExecutor.Execute(query);

            if (getWarehause == null)
            {
                return new GetWarehauseByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedWarehause = this.mapper.Map<Warehause>(getWarehause);
            return new GetWarehauseByIdResponse()
            {
                Data = mappedWarehause
            };
        }
    }
}
