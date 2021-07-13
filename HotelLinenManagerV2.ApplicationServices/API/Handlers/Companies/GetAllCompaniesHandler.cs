using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
using HotelLinenManagerV2.ApplicationServices.Components.GUSDataConnector;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Companies;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Companies
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesRequest, GetAllCompaniesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        private readonly IGUSDataConnector gUSDataConnector;

        public GetAllCompaniesHandler(IQueryExecutor queryExecutor, IMapper mapper, IGUSDataConnector gUSDataConnector)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
            this.gUSDataConnector = gUSDataConnector;
        }

        public async Task<GetAllCompaniesResponse> Handle(GetAllCompaniesRequest request, CancellationToken cancellationToken)
        {

            var query = new GetCompaniesQuery()
            {
                Name = request.Name,
                TaxNumber = request.TaxNumber,
                CompanyId = request.AuthenticationCompanyId
            };
            var companiesFromDb = await this.queryExecutor.Execute(query);
            if (companiesFromDb == null)
            {
                return new GetAllCompaniesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedCompanies = this.mapper.Map<List<Company>>(companiesFromDb);
            var response = new GetAllCompaniesResponse()
            {
                Data = mappedCompanies
            };
            return response;
        }
    }
}
