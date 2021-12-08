using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Invoices;
using HotelLinenManagerV2.ApplicationServices.Components.DocNumCreator;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Invoices;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Invoices;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Invoices
{
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceRequest, CreateInvoiceResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        private readonly IDocNumCreator docNumCreator;
        private string lastDocNumber;

        public CreateInvoiceHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper, IDocNumCreator docNumCreator)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
            this.docNumCreator = docNumCreator;

        }

        public async Task<CreateInvoiceResponse> Handle(CreateInvoiceRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceQuery()
            {
                Number = request.Number,
                CompanyId = request.AuthenticationCompanyId,
                LaundryId = request.LaundryId,
                WouldLikeToCreate = true
            };
            var getInvoice = await this.queryExecutor.Execute(query);
            if (getInvoice != null)
            {
                lastDocNumber = getInvoice.Number;
            }
            else
            {
                lastDocNumber = "0/0/0";
            }
            request.Number = docNumCreator.DocumentNumberCreator(lastDocNumber);

            var mappedCommand = this.mapper.Map<DataAccess.Entities.Invoice>(request);
            var command = new CreateInvoiceCommand()
            {
                Parameter = mappedCommand
            };
            var created = await this.commandExecutor.Execute(command);

            var response = new CreateInvoiceResponse()
            {

                Data = this.mapper.Map<API.Domain.Models.Invoice>(created)

            };

            return response;
        }
    }
}


