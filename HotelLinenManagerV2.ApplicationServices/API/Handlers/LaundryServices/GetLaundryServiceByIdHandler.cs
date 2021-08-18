using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServices;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.LaundryServiceDetails
{
    public class GetLaundryServiceByIdHandler : IRequestHandler<GetLaundryByIdRequest, GetLaundryByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryexecutor;

        public GetLaundryServiceByIdHandler(IMapper mapper, IQueryExecutor queryexecutor)
        {
            this.mapper = mapper;
            this.queryexecutor = queryexecutor;
        }

        public async Task<GetLaundryByIdResponse> Handle(GetLaundryByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLaundryQuery()
            {
                Id = request.Id
            };
            var detail = await this.queryexecutor.Execute(query);
            if (detail == null)
            {
                return new GetLaundryByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDetail = this.mapper.Map<LaundryService>(detail);
            return new GetLaundryByIdResponse()
            {
                Data = mappedDetail
            };
        }
    }
}
