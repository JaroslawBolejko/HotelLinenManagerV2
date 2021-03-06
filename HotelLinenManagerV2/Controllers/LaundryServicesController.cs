using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
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
    public class LaundryServicesController : ApiControllerBase
    {
        public LaundryServicesController(IMediator mediator, ILogger<LaundryServicesController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in LaundryService");

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllLaundry([FromQuery] GetAllLaundryRequest request)
        {
            return await this.HandleRequest<GetAllLaundryRequest, GetAllLaundryResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLaundryById([FromRoute] int id)
        {
            var request = new GetLaundryByIdRequest()
            {
                Id = id
            };
            return await this.HandleRequest<GetLaundryByIdRequest, GetLaundryByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateLaundry([FromBody] CreateLaundryRequest request)
        {
            return await this.HandleRequest<CreateLaundryRequest, CreateLaundryResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLaundryById([FromRoute] int id, [FromBody] UpdateLaundryByIdRequest request)
        {
            request.Id = id;
            return await this.HandleRequest<UpdateLaundryByIdRequest, UpdateLaundryResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLaundryById([FromRoute] int id)
        {
            var request = new DeleteLaundryByIdRequest()
            {
                Id = id
            };
            return await this.HandleRequest<DeleteLaundryByIdRequest, DeleteLaundryResponse>(request);
        }
    }
}
