using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
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
    public class PriceListDetailsController : ApiControllerBase
    {
        public PriceListDetailsController(IMediator mediator, ILogger<PriceListDetailsController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in PriceListDetails");
        }
            [HttpGet]
            [Route("")]
            public async Task<IActionResult> GetAllPriceListsDetails([FromQuery] GetAllPriceListDetailsRequest request)
            {
                return await this.HandleRequest<GetAllPriceListDetailsRequest, GetAllPriceListDetailsResponse>(request);
            }

            [HttpGet]
            [Route("{priceListDetailId}")]
            public async Task<IActionResult> GetPriceListDetailById([FromRoute] int priceListDetailId)
            {
                var request = new GetPriceListDetailsByIdRequest()
                {
                    Id = priceListDetailId
                };
                return await this.HandleRequest<GetPriceListDetailsByIdRequest, GetPriceListDetailsByIdResponse>(request);
            }

            [HttpPost]
            [Route("")]
            public async Task<IActionResult> CreatePriceListDetail([FromBody] CreatePriceListDetailRequest request)
            {
                return await this.HandleRequest<CreatePriceListDetailRequest, CreatePriceListDetailResponse>(request);
            }

            [HttpPut]
            [Route("{priceListDetailId}")]
            public async Task<IActionResult> UpdatePriceListDetail([FromRoute] int priceListDetailId, [FromBody] UpdatePriceListDetailsRequest request)
            {
                request.Id = priceListDetailId;
                return await this.HandleRequest<UpdatePriceListDetailsRequest, UpdatePriceListDetailsResponse>(request);
            }
            [HttpDelete]
            [Route("{priceListDetailId}")]
            public async Task<IActionResult> DeletePriceListDetail([FromRoute] int priceListDetailId)
            {
                var request = new DeletePriceListDetailsRequest()
                {
                    Id = priceListDetailId
                };
                return await this.HandleRequest<DeletePriceListDetailsRequest, DeletePriceListDetailsResponse>(request);
            }
        }
    }

