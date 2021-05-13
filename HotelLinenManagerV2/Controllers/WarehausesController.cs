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

    public class WarehausesesController : ControllerBase/*ApiControllerBase*/
    {
        private readonly IMediator mediator;

        public WarehausesesController(IMediator mediator/*, ILogger<WarehausesesController logger*/) /*: base(mediator, logger)*/
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
        [Route("")]
        public async Task<IActionResult> PutWarehauseById([FromBody] PutWarehauseByIdRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
            //  return this.HandleRequest<PutWarehauseByIdRequest, PutWarehauseByIdResponse>(request);

        }

        [HttpDelete]
        [Route("{warehauseId}")]
        public async Task<IActionResult> DeleteWarehauseById([FromRoute] DeleteWarehauseByIdRequest request)
        {

            //var request = new GetWarehauseByIdRequest()
            //{
            //    WarehauseId = warehauseId
            //};
            var response = await this.mediator.Send(request);
            return this.Ok(response);
            // return this.HandleRequest<DeleteWarehauseByIdRequest, DeleteWarehauseByIdResponse>(request);

        }
    }
}
