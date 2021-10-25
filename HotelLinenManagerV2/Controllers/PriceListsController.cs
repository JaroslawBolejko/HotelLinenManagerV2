using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceLists;
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
    public class PriceListsController : ApiControllerBase
    {
        public PriceListsController(IMediator mediator, ILogger<PriceListsController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in PriceList");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPriceLists([FromQuery] GetAllPriceListsRequest request)
        {
            return await this.HandleRequest<GetAllPriceListsRequest, GetAllPriceListsResponse>(request);
        }

        [HttpGet]
        [Route("{priceListId}")]
        public async Task<IActionResult> GetPricListById([FromRoute] int priceListId)
        {
            var request = new GetPriceListByIdRequest()
            {
                Id = priceListId
            };
            return await this.HandleRequest<GetPriceListByIdRequest, GetPriceListByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreatePriceList([FromBody] CreatePriceListRequest request)
        {
            return await this.HandleRequest<CreatePriceListRequest, CreatePriceListResponse>(request);
        }

        [HttpPut]
        [Route("{priceListId}")]
        public async Task<IActionResult> UpdatePriceListById([FromRoute] int priceListId, [FromBody] UpdatePriceListByIdRequest request)
        {
            request.Id = priceListId;
            return await this.HandleRequest<UpdatePriceListByIdRequest, UpdatePriceListByIdResponse>(request);
        }
        [HttpDelete]
        [Route("{priceListId}")]
        public async Task<IActionResult> DeletePriceListById([FromRoute] int priceListId)
        {
            var request = new DeletePriceListByIdRequest()
            {
                Id = priceListId
            };
            return await this.HandleRequest<DeletePriceListByIdRequest, DeletePriceListByIdResponse>(request);
        }
    }
}
