using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;
using HotelLinenManagerV2.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]

    public class WarehausesController : ControllerBase/*ApiControllerBase*/
    {
        private readonly IMediator mediator;

        public WarehausesController(IMediator mediator/*, ILogger<WarehausesController logger*/) /*: base(mediator, logger)*/
        {
            //  logger.LogInformation("We are in Warehauses");
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllWarehausess([FromQuery] GetAllWarehausesRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
            // return this.HandleRequest<GetAllWarehausesRequest, GetAllWarehausesResponse>(request);
        }

        [HttpGet]
        [Route("{warehauseId}")]
        public async Task<IActionResult> GetById([FromRoute] int warehauseId)
        {

            var request = new GetWarehauseByIdRequest()
            {
                WarehauseId = warehauseId
            };

            var response = await this.mediator.Send(request);
            return this.Ok(response);
            // return this.HandleRequest<GetWarehauseByIdRequest, GetWarehauseByIdResponse>(request);

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateWarehause([FromBody] CreateWarehauseRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
            // return this.HandleRequest<CreateWarehauseRequest, CreateWarehauseResponse>(request);
        }

        [HttpPut]
        [Route("{warehauseId}")]
        public async Task<IActionResult> UpdateWarehauseById([FromBody]  UpdateWarehauseByIdRequest request, int warehauseId)
        {
            request.id = warehauseId;
            var response = await this.mediator.Send(request);
            return this.Ok(response);
            //  return this.HandleRequest<UpdateWarehauseByIdRequest, UpdateWarehauseByIdResponse>(request);

        }

        [HttpDelete]
        [Route("{warehauseId}")]
        public async Task<IActionResult> DeleteWarehauseById([FromRoute] int warehauseId)
        {

            var request = new DeleteWarehauseByIdRequest()
            {
                Id = warehauseId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
            // return this.HandleRequest<DeleteWarehauseByIdRequest, DeleteWarehauseByIdResponse>(request);

        }
    }
}
