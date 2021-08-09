using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.WarehauseDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WarehauseDetailsController : ApiControllerBase
    {
        public WarehauseDetailsController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Warehause details");

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllDetails([FromQuery] GetAllDetailsRequest request)
        {
            return await this.HandleRequest<GetAllDetailsRequest, GetAllDetailsResponse>(request);
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetDetailsById([FromRoute] int Id)
        {
            var request = new GetDetailsByIdRequest()
            {
                Id = Id
            };
            return await this.HandleRequest<GetDetailsByIdRequest, GetDetailsByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateDetails([FromBody] CreateDetailsRequest request)
        {
            return await this.HandleRequest<CreateDetailsRequest, CreateDetailsResponse>(request);
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateDetailsById([FromRoute] int Id, [FromBody] UpdateDetailsRequest request)
        {
            request.Id = Id;
            return await this.HandleRequest<UpdateDetailsRequest, UpdateDetailsResponse>(request);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteDetailsById([FromRoute] int Id)
        {
            var request = new DeleteDetailsByIdRequest()
            {
                Id = Id
            };
            return await this.HandleRequest<DeleteDetailsByIdRequest, DeleteDetailsByIdResponse>(request);
        }
    }
}
