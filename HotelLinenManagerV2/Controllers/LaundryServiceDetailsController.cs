using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServiceDetails;
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
    public class LaundryServiceDetailsController : ApiControllerBase
    {
        public LaundryServiceDetailsController(IMediator mediator, ILogger<LaundryServiceDetailsController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in LaundryServiceDetails");

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllLaundryDetails([FromQuery] GetAllLaundryDetailsRequest request)
        {
            return await this.HandleRequest<GetAllLaundryDetailsRequest, GetAllLaundryDetailsResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLaundryDetailsById([FromRoute] int id)
        {
            var request = new GetLaundryDetailsByIdRequest()
            {
                Id = id
            };
            return await this.HandleRequest<GetLaundryDetailsByIdRequest, GetLaundryDetailsByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateLaundryDetails([FromBody] CreateLaundryDetailsRequest request)
        {
            return await this.HandleRequest<CreateLaundryDetailsRequest, CreateLaundryDetailsResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLaundryDetailsById([FromRoute] int id, [FromBody] UpdateLaundryDetailsRequest request)
        {
            request.Id = id;
            return await this.HandleRequest<UpdateLaundryDetailsRequest, UpdateLaundryDetailsResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLaundryDetailsById([FromRoute] int id)
        {
            var request = new DeleteLaundryDetailsByIdRequest()
            {
                Id = id
            };
            return await this.HandleRequest<DeleteLaundryDetailsByIdRequest, DeleteLaundryDetailsByIdResponse>(request);
        }
    }
}

