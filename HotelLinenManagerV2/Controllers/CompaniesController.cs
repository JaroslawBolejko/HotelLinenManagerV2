using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompaniesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCompanies([FromQuery]GetAllCompaniesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{companyId}")]
        public async Task<IActionResult> GetCompanyById([FromRoute] int companyId)
        {
            var request = new GetCompanyByIdRequest()
            {
                Id = companyId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("{companyId}")]
        public async Task<IActionResult> UpdateCompanyById([FromBody] UpdateCompanyByIdRequest request, int companyId)
        {
            request.id = companyId;
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpDelete]
        [Route("{companyId}")]
        public async Task<IActionResult> DeleteCompanyById([FromRoute] int companyId)
        {
            var request = new DeleteCompanyByIdRequest()
            {
                Id = companyId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
