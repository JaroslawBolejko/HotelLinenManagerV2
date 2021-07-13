using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
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
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllHotelLinensHandler(IQueryExecutor queryExecutor,IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetAllHotelLinenResponse> Handle(GetAllHotelLinenRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserLaundry")
            {
                return new GetAllHotelLinenResponse
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetHotelLinensQuery()
            {
             NameWithShortDescription = request.NameWithShortDescription,   
             HotelLinenTypeId = request.HotelLinenTypeId,
             CompanyId = request.AuthenticationCompanyId
            };
            var getHotelLinen = await this.queryExecutor.Execute(query);

            if (getHotelLinen == null)
            {
                return new GetAllHotelLinenResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
          
            var mappedHotelLinen = this.mapper.Map<List<HotelLinen>>(getHotelLinen);
            var response = new GetAllHotelLinenResponse()
            {
                Data = mappedHotelLinen
            };
            return response;

            
        }
    }
}
