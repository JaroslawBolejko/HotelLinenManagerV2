using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelLinensController : ApiControllerBase
    {

        public HotelLinensController(IMediator mediator,ILogger<HotelLinensController> logger) : base(mediator,logger)
        {
            logger.LogInformation("We are in HotelLinen");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllHotelLinen([FromQuery] GetAllHotelLinenRequest request)
        {
            return await this.HandleRequest<GetAllHotelLinenRequest, GetAllHotelLinenResponse>(request);
        }

        [HttpGet]
        [Route("{hotelLinenId}")]
        public async Task<IActionResult> GetHotelLinenById([FromRoute] int hotelLinenId)
        {
            var request = new GetHotelLinenByIdRequest()
            {
                Id = hotelLinenId
            };
            return await this.HandleRequest<GetHotelLinenByIdRequest, GetHotelLinenByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateHotelLinen([FromBody] CreateHotelLinenRequest request)
        {
            return await this.HandleRequest<CreateHotelLinenRequest, CreateHotelLinenResponse>(request);
        }
        [HttpPut]
        [Route("{hotelLinenId}")]
        public async Task<IActionResult> UpdateHotelLinenById([FromBody] UpdateHotelLinenByIdRequest request, int hotelLinenId)
        {
            request.id = hotelLinenId;
            return await this.HandleRequest<UpdateHotelLinenByIdRequest, UpdateHotelLinenByIdResponse>(request);
        }

        //[HttpPatch]
        //[Route("{hotelLinenId}")]
        //public async Task<IActionResult> PatchHotelLinenById(int hotelLinenId,[FromBody] PatchHotelLinenByIdRequest request)
        //{
           
        //    return await this.HandleRequest<PatchHotelLinenByIdRequest, PatchHotelLinenByIdResponse>(request);
        //}

        [HttpDelete]
        [Route("{hotelLinenId}")]
        public async Task<IActionResult> DeleteHotelLinenById([FromRoute] int hotelLinenId)
        {
            var request = new DeleteHotelLinenByIdRequest()
            {
                Id = hotelLinenId
            };
            return await this.HandleRequest<DeleteHotelLinenByIdRequest, DeleteHotelLinenByIdResponse>(request);
        }

    }
}
