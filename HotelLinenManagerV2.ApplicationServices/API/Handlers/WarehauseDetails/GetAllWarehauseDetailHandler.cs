using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.WarehauseDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.WarehauseDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.WarehauseDetails
{
    public class GetAllLaundryServiceDetailsHandler : IRequestHandler<GetAllDetailsRequest, GetAllDetailsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllLaundryServiceDetailsHandler(IMapper mapper,IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllDetailsResponse> Handle(GetAllDetailsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllWarehauseDetailsQuery()
            {
               HotelLinenId = request.HotelLinenId,
               WarehauseId = request.WarehauseId,
               CompanyId = request.AuthenticationCompanyId
            };
            var details = await this.queryExecutor.Execute(query);
            var mappedDetails = this.mapper.Map<List<WarehauseDetail>>(details);

            if (mappedDetails == null)
            {
                return new GetAllDetailsResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }
            return new GetAllDetailsResponse()
            {
                Data = mappedDetails
            };
            

        }
    }
}
