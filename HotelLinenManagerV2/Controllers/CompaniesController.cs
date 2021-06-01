using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ApiControllerBase
    {
       public CompaniesController(IMediator mediator) : base(mediator)
        {

        } 

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCompanies([FromQuery] GetAllCompaniesRequest request)
        {
            return await this.HandleRequest<GetAllCompaniesRequest, GetAllCompaniesResponse>(request);
        }

        [HttpGet]
        [Route("{companyId}")]
        public async Task<IActionResult> GetCompanyById([FromRoute] int companyId)
        {
            var request = new GetCompanyByIdRequest()
            {
                Id = companyId
            };
            return await this.HandleRequest<GetCompanyByIdRequest, GetCompanyByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest request)
        {
            return await this.HandleRequest<CreateCompanyRequest, CreateCompanyResponse>(request);
        }

        [HttpPut]
        [Route("{companyId}")]
        public async Task<IActionResult> UpdateCompanyById([FromBody] UpdateCompanyByIdRequest request, int companyId)
        {
            request.id = companyId;
            return await this.HandleRequest<UpdateCompanyByIdRequest, UpdateCompanyByIdResponse>(request);
        }
        [HttpDelete]
        [Route("{companyId}")]
        public async Task<IActionResult> DeleteCompanyById([FromRoute] int companyId)
        {
            var request = new DeleteCompanyByIdRequest()
            {
                Id = companyId
            };
            return await this.HandleRequest<DeleteCompanyByIdRequest, DeleteCompanyByIdResponse>(request);
        }

    }
}
