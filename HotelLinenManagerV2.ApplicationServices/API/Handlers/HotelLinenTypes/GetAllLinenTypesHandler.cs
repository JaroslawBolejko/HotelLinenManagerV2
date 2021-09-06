using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinenTypes;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinenTypes;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinenTypes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.HotelLinens
{
    public class GetAllLinenTypesHandler : IRequestHandler<GetAllLinenTypesRequest, GetAllLinenTypesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllLinenTypesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetAllLinenTypesResponse> Handle(GetAllLinenTypesRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new GetAllLinenTypesResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetAllLinenTypesQuery()
            {
                CompanyId = request.AuthenticationCompanyId,
            };
            var linenTypes = await this.queryExecutor.Execute(query);

            if (linenTypes == null)
            {
                return new GetAllLinenTypesResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedLinenTypes = this.mapper.Map<List<HotelLinenType>>(linenTypes);
            var response = new GetAllLinenTypesResponse()
            {
                Data = mappedLinenTypes
            };
            return response;


        }
    }
}
