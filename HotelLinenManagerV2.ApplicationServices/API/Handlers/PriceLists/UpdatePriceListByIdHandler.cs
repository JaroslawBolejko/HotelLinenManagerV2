using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceLists;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceLists;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.PriceLists
{
    public class UpdatePriceListByIdHandler : IRequestHandler<UpdatePriceListByIdRequest, UpdatePriceListByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public UpdatePriceListByIdHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {

            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<UpdatePriceListByIdResponse> Handle(UpdatePriceListByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPriceQuery()
            {
                Id = request.Id
            };
            var prices = await this.queryExecutor.Execute(query);
            if (prices == null)
            {
                return new UpdatePriceListByIdResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedPrices = this.mapper.Map<PriceList>(request);
            var command = new UpdatePriceListCommand()
            {
                Parameter = mappedPrices
            };
            var updatedPriceList = await this.commandExecutor.Execute(command);
            return new UpdatePriceListByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.PriceList>(updatedPriceList)
            };
        }
    }
}
