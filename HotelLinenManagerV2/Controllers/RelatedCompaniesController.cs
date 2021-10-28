using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.RelatedCompanies;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.RelatedCompanies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RelatedCompaniesController : ApiControllerBase
    {
        public RelatedCompaniesController(IMediator mediator, ILogger<RelatedCompaniesController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in RelatedCompanies");
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllRelatedCompanies([FromQuery] GetAllRelatedCompaniesRequest request)
        {
            return await this.HandleRequest<GetAllRelatedCompaniesRequest, GetAllRelatedCompaniesResponse>(request);
        }
              
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateRelatedCompany([FromBody] CreateRelatedCompanyRequest request)
        {
            return await this.HandleRequest<CreateRelatedCompanyRequest, CreateRelatedCompanyResponse>(request);
        }

        [HttpDelete]
        [Route("{reletedId}")]
        public async Task<IActionResult> DeleteRelatedCompany([FromRoute] int reletedId)
        {
            var request = new DeleteRelatedCompanyRequest()
            {
                Id = reletedId
            };
            return await this.HandleRequest<DeleteRelatedCompanyRequest, DeleteRelatedCompanyResponse>(request);
        }
    }
}
