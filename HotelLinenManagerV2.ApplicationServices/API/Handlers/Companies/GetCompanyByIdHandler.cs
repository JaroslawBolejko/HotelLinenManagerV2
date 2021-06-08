using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Companies;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Companies
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdRequest, GetCompanyByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetCompanyByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetCompanyByIdResponse> Handle(GetCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCompanyQuery() 
            {
                Id = request.Id
            };
            var companyFromDb = await this.queryExecutor.Execute(query);

            if (companyFromDb == null)
            {
                return new GetCompanyByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var response = new GetCompanyByIdResponse()

            {
                Data = this.mapper.Map<API.Domain.Models.Company>(companyFromDb)
            };
            return response;
        }
    }
}
