using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServices;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.LaundryServiceDetails
{
    public class GetAllLaundryServiceHandler : IRequestHandler<GetAllLaundryRequest, GetAllLaundryResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllLaundryServiceHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllLaundryResponse> Handle(GetAllLaundryRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllLaundryQuery()
            {
                Number = request.Number,
                CompanyId = request.AuthenticationCompanyId,
                PageSize = request.PageSize,
                PageNumber = request.PageNumber
            }; 
            var details = await this.queryExecutor.Execute(query);
            var mappedDetails = this.mapper.Map<List<LaundryService>>(details);

            if (mappedDetails == null)
            {
                return new GetAllLaundryResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }
            return new GetAllLaundryResponse()
            {
                Data = mappedDetails
            };


        }
    }
}
