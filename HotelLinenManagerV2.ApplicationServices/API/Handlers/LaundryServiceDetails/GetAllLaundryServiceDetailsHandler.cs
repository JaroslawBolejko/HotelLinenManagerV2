using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServiceDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServiceDetails;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.LaundryServiceDetails
{
    public class GetAllLaundryServiceDetailsHandler : IRequestHandler<GetAllLaundryDetailsRequest, GetAllLaundryDetailsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllLaundryServiceDetailsHandler(IMapper mapper,IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllLaundryDetailsResponse> Handle(GetAllLaundryDetailsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllLaundryDetailsQuery()
            {
                LaundryServiceId = request.LaundryServiceId,
                CompanyId = request.AuthenticationCompanyId
            };
            var details = await this.queryExecutor.Execute(query);
            var mappedDetails = this.mapper.Map<List<LaundryServiceDetail>>(details);

            if (mappedDetails == null)
            {
                return new GetAllLaundryDetailsResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }
            return new GetAllLaundryDetailsResponse()
            {
                Data = mappedDetails
            };
            

        }
    }
}
