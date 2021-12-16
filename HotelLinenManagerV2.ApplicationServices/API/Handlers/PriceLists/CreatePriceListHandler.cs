using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
using HotelLinenManagerV2.ApplicationServices.Components.DocNumCreator;
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
    public class CreatePriceListHandler : IRequestHandler<CreatePriceListRequest, CreatePriceListResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        private readonly IDocNumCreator docNumCreator;
        private string lastDocNumber;
        public CreatePriceListHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper, IDocNumCreator docNumCreator)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
            this.docNumCreator = docNumCreator;
        }

        public async Task<CreatePriceListResponse> Handle(CreatePriceListRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticationRole == "UserHotel" || request.AuthenticationRole == "UserAdmin")
            {
                return new CreatePriceListResponse
                {
                    Error = new ErrorModel(ErrorType.Forbidden)
                };

            }

            var query = new GetPriceQuery()
            {
                CompanyId = request.AuthenticationCompanyId,
                LaundryId = request.LaundryId,
                WouldLikeToCreate = true
            };
            var lastPriceList = await this.queryExecutor.Execute(query);
            if (lastPriceList != null)
            {
                lastDocNumber = lastPriceList.DocNumber;
            }
            else
            {
                lastDocNumber = "0/0/0";
            }
            request.Number = docNumCreator.DocumentNumberCreator(lastDocNumber);

            var mappedPrices = this.mapper.Map<PriceList>(request);
            var command = new CreatePriceListCommand()
            {
                Parameter = mappedPrices
            };
            var createdPriceList = await this.commandExecutor.Execute(command);
            return new CreatePriceListResponse()
            {
                Data = this.mapper.Map<Domain.Models.PriceList>(createdPriceList)
            };
        }
    }
}
