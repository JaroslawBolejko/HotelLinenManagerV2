using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using HotelLinenManagerV2.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HotelLinensController : ApiControllerBase
    {
        private readonly IMediator mediator;
        private readonly WarehauseStorageHotelLinenContext context;
        private readonly IMapper mapper;

        public HotelLinensController(IMediator mediator,ILogger<HotelLinensController> logger,
            WarehauseStorageHotelLinenContext context, IMapper mapper) : base(mediator,logger)
        {
            logger.LogInformation("We are in HotelLinen");
            this.mediator = mediator;
            this.context = context;
            this.mapper = mapper;
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

        
        [HttpPatch]
        [Route("{hotellinenId}")]
        public async Task<IActionResult> PatchHotelLinen(int hotellinenId,
            [FromBody] JsonPatchDocument<HotelLinen> linenUpdate)
        {
            //var entity =  this.context.HotelLinens.FirstOrDefault(x => x.Id == hotellinenId);
            //var mappedHotelLinen = this.mapper.Map<HotelLinen>(entity);
            
            //linenUpdate.ApplyTo(mappedHotelLinen);

            //var mappedHotelLinen2 = this.mapper.Map<DataAccess.Entities.HotelLinen>(mappedHotelLinen);

            //context.ChangeTracker.Clear();
            //context.HotelLinens.Update(mappedHotelLinen2);
            //await context.SaveChangesAsync();

            //return NoContent();

            var request = new PatchHotelLinenByIdRequest()
            {
                Id = hotellinenId,
               LinenUpdate = linenUpdate

            };

            return await this.HandleRequest<PatchHotelLinenByIdRequest, PatchHotelLinenByIdResponse>(request);
        }

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
