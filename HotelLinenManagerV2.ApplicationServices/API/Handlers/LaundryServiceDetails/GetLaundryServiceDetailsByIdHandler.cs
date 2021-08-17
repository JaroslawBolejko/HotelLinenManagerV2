using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServiceDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServiceDetails;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.LaundryServiceDetails
{
    public class GetLaundryServiceDetailsByIdHandler : IRequestHandler<GetLaundryDetailsByIdRequest, GetLaundryDetailsByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryexecutor;

        public GetLaundryServiceDetailsByIdHandler(IMapper mapper, IQueryExecutor queryexecutor)
        {
            this.mapper = mapper;
            this.queryexecutor = queryexecutor;
        }

        public async Task<GetLaundryDetailsByIdResponse> Handle(GetLaundryDetailsByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLaundryDetailsQuery()
            {
                Id = request.Id
            };
            var detail = await this.queryexecutor.Execute(query);
            if (detail == null)
            {
                return new GetLaundryDetailsByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDetail = this.mapper.Map<LaundryServiceDetail>(detail);
            return new GetLaundryDetailsByIdResponse()
            {
                Data = mappedDetail
            };
        }
    }
}
