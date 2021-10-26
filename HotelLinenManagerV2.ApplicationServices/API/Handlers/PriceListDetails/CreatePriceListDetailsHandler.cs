using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceListDetails;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceListDetails;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.PriceListDetails
{
    public class CreatePriceListDetailsHandler : IRequestHandler<CreatePriceListDetailRequest, CreatePriceListDetailResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public CreatePriceListDetailsHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<CreatePriceListDetailResponse> Handle(CreatePriceListDetailRequest request, CancellationToken cancellationToken)
        {
            //var query = new GetAllPriceListDetailsQuery()
            //{
            //    CompanyId = request.AuthenticationCompanyId
            //};
            //var prices = await this.queryExecutor.Execute(query);
            //if (prices != null)
            //{
            //    return new CreatePriceListDetailResponse()
            //    {
            //        Error = new Domain.ErrorHandling.ErrorModel(ErrorType.Conflict)
            //    };
            //}
            var mappedPrices = this.mapper.Map<PriceListDetail>(request);
            var command = new CreatePriceListDetailsCommand()
            {
                Parameter = mappedPrices
            };
            var createdPriceList = await this.commandExecutor.Execute(command);
            return new CreatePriceListDetailResponse()
            {
                Data = this.mapper.Map<Domain.Models.PriceListDetail>(createdPriceList)
            };
        }
    }
}
