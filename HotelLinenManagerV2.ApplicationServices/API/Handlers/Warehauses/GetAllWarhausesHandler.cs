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
    public class GetAllWarhausesHandler : IRequestHandler<GetAllWarehausesRequest, GetAllWarehausesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllWarhausesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetAllWarehausesResponse> Handle(GetAllWarehausesRequest request, CancellationToken cancellationToken)
        {
            if(request.AuthenticationRole == "UserLaundry")
            {
                return new GetAllWarehausesResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.Forbidden)
                };
            }
            var query = new GetWarehausesQuery() 
            {
                WarehauseNumber=request.WarehauseNumber,
                CompanyId = request.AuthenticationCompanyId,
                WarehauseType=  request.WarehauseType
            };
            var getWarehauses = await this.queryExecutor.Execute(query);

            if(getWarehauses==null)
            {
                return new GetAllWarehausesResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedWarehase = this.mapper.Map<List<Warehause>>(getWarehauses);

            return new GetAllWarehausesResponse()
            {
                Data = mappedWarehase
            };
        }
    }
}
