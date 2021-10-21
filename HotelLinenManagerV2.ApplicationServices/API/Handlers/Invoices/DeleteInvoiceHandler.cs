using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Invoices;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Invoices;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Invoices
{
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceByIdRequest, DeleteInvoiceByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public DeleteInvoiceHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteInvoiceByIdResponse> Handle(DeleteInvoiceByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceQuery()
            {
                Id = request.Id
            };
            var getInvoice = await this.queryExecutor.Execute(query);
            if (getInvoice == null)
            {
                return new DeleteInvoiceByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedCommand = this.mapper.Map<DataAccess.Entities.Invoice>(request);
            var command = new DeleteInvoiceCommand()
            {
                Parameter = mappedCommand
            };
            var created = await this.commandExecutor.Execute(command);

            var response = new DeleteInvoiceByIdResponse()
            {

                Data = created

            };

            return response;
        }
    }
}

