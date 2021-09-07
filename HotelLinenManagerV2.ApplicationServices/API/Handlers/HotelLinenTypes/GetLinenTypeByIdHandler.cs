using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinenTypes;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinenTypes;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.HotelLinenTypes;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.HotelLinens
{
    public class GetLinenTypeByIdHandler : IRequestHandler<GetLinenTypeByIdRequest, GetLinenTypeByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetLinenTypeByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetLinenTypeByIdResponse> Handle(GetLinenTypeByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new GetLinenTypeByIdResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetLinenTypeQuery()
            {
                Id = request.Id
            };

            var linenType = await this.queryExecutor.Execute(query);
            if (linenType == null)
            {
                return new GetLinenTypeByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedType = this.mapper.Map<HotelLinenType>(linenType);
            var response = new GetLinenTypeByIdResponse()
            {
                Data = mappedType
            };
            return response;
        }
    }
}
