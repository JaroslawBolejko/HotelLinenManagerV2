using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinenTypes;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinenTypes;
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
    public class HotelLinenTypesController : ApiControllerBase
    {
        public HotelLinenTypesController(IMediator mediator, ILogger<HotelLinenTypesController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in HotelLinenTypes");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllLinen([FromQuery] GetAllLinenTypesRequest request)
        {
            return await this.HandleRequest<GetAllLinenTypesRequest, GetAllLinenTypesResponse>(request);
        }

        [HttpGet]
        [Route("{typeId}")]
        public async Task<IActionResult> GetLinenTypeById([FromRoute] int typeId)
        {
            var request = new GetLinenTypeByIdRequest()
            {
                Id = typeId
            };
            return await this.HandleRequest<GetLinenTypeByIdRequest, GetLinenTypeByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateLinentype([FromBody] CreateLinenTypeRequest request)
        {
            return await this.HandleRequest<CreateLinenTypeRequest, CreateLinenTypeResponse>(request);
        }

        [HttpPut]
        [Route("{typeId}")]
        public async Task<IActionResult> UpdateTypeById([FromRoute] int typeId, [FromBody] UpdateLinenTypeByIdRequest request)
        {
            request.Id = typeId;
            return await this.HandleRequest<UpdateLinenTypeByIdRequest, UpdateLinenTypeByIdResponse>(request);
        }
        [HttpDelete]
        [Route("{typeId}")]
        public async Task<IActionResult> DeleteTypeById([FromRoute] int typeId)
        {
            var request = new DeleteLinenTypeByIdRequest()
            {
                Id = typeId
            };
            return await this.HandleRequest<DeleteLinenTypeByIdRequest, DeleteLinenTypeByIdResponse>(request);
        }

    }

}

