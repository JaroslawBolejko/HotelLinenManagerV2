using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelLinensController : ControllerBase
    {
        private readonly IMediator mediator;

        public HotelLinensController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllHotelLinen([FromQuery] GetAllHotelLinenRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{hotelLinenId}")]
        public async Task<IActionResult> GetHotelLinenById([FromRoute] int hotelLinenId)
        {
            var request = new GetHotelLinenByIdRequest()
            {
                Id = hotelLinenId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateHotelLinen([FromBody] CreateHotelLinenRequest request)
        {
            var resopnse = await this.mediator.Send(request);
            return this.Ok(resopnse);

        }
        [HttpPut]
        [Route("{hotelLinenId}")]
        public async Task<IActionResult> UpdateHotelLinenById([FromBody] UpdateHotelLinenByIdRequest request, int hotelLinenId)
        {
            request.id = hotelLinenId;
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{hotelLinenId}")]
        public async Task<IActionResult> DeleteHotelLinenById([FromRoute] int hotelLinenId )
        {
            var request = new DeleteHotelLinenByIdRequest()
            {
                Id = hotelLinenId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
