using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
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

    public class WarehausesController : ApiControllerBase
    {


        public WarehausesController(IMediator mediator, ILogger<WarehausesController> logger) : base(mediator, logger)
        {
             logger.LogInformation("We are in Warehauses");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllWarehausess([FromQuery] GetAllWarehausesRequest request)
        {
            return await this.HandleRequest<GetAllWarehausesRequest, GetAllWarehausesResponse>(request);
        }

        [HttpGet]
        [Route("{warehauseId}")]
        public async Task<IActionResult> GetById([FromRoute] int warehauseId)
        {

            var request = new GetWarehauseByIdRequest()
            {
                WarehauseId = warehauseId
            };

            return await this.HandleRequest<GetWarehauseByIdRequest, GetWarehauseByIdResponse>(request);

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateWarehause([FromBody] CreateWarehauseRequest request)
        {
            return await this.HandleRequest<CreateWarehauseRequest, CreateWarehauseResponse>(request);
        }

        [HttpPut]
        [Route("{warehauseId}")]
        public async Task<IActionResult> UpdateWarehauseById([FromBody] UpdateWarehauseByIdRequest request, int warehauseId)
        {
            request.id = warehauseId;
            return await this.HandleRequest<UpdateWarehauseByIdRequest, UpdateWarehauseByIdResponse>(request);
        }

        [HttpDelete]
        [Route("{warehauseId}")]
        public async Task<IActionResult> DeleteWarehauseById([FromRoute] int warehauseId)
        {
            var request = new DeleteWarehauseByIdRequest()
            {
                Id = warehauseId
            };
            return await this.HandleRequest<DeleteWarehauseByIdRequest, DeleteWarehauseByIdResponse>(request);
        }
    }
}
