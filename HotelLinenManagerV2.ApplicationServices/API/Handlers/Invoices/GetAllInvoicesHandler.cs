using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Invoices;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Invoices;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Invoices
{
    public class GetAllInvoicesHandler : IRequestHandler<GetAllInvoicesRequest, GetAllInvoicesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllInvoicesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetAllInvoicesResponse> Handle(GetAllInvoicesRequest request, CancellationToken cancellationToken)
        {

            var query = new GetAllInvoicesQuery()
            {
              CompanyId = request.AuthenticationCompanyId,
              UserRole = request.AuthenticationRole.ToString()
            };
                                        
            var invoice = await this.queryExecutor.Execute(query);

            if (invoice == null)
            {
                return new GetAllInvoicesResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedInvoices = this.mapper.Map<List<Invoice>>(invoice);
            return new GetAllInvoicesResponse()
            {
                Data = mappedInvoices
            };
        }
    }
}
