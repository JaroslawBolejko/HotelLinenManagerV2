using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Invoices;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Invoices;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Invoices;
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

        public CreateInvoiceHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateInvoiceResponse> Handle(CreateInvoiceRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceQuery()
            {
                Number = request.Number
            };
            var getInvoice = await this.queryExecutor.Execute(query);
            if (getInvoice != null)
            {
                return new CreateInvoiceResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }
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


