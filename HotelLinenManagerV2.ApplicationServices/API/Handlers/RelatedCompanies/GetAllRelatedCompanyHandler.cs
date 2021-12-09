using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.RelatedCompanies;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.RelatedCompanies;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.RelatedCompanies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.RelatedCompanies
{
    public class GetAllRelatedCompanyHandler : IRequestHandler<GetAllRelatedCompaniesRequest, GetAllRelatedCompaniesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllRelatedCompanyHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetAllRelatedCompaniesResponse> Handle(GetAllRelatedCompaniesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllRelatedCompaniesQuery();

            if (request.AuthenticationRole.ToString() == "UserLaundry")
            {

                query.LaundryId = request.AuthenticationCompanyId;
                
            }
            else
            {

                query.CompanyId = request.AuthenticationCompanyId;
                
            }
           
            var users = await this.queryExecutor.Execute(query);
            var mappedRelatedComp = this.mapper.Map<List<RelatedCompany>>(users);
            var response = new GetAllRelatedCompaniesResponse()
            {
                Data = mappedRelatedComp
            };
            return response;
        }
    }
}
