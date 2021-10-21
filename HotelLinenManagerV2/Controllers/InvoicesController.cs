using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Invoices;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Invoices;
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
    public class InvoicesController : ApiControllerBase
    {
        public InvoicesController(IMediator mediator, ILogger<InvoicesController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Invoice");

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllInvoices([FromQuery] GetAllInvoicesRequest request)
        {
            return await this.HandleRequest<GetAllInvoicesRequest, GetAllInvoicesResponse>(request);
        }

        [HttpGet]
        [Route("{invoiceId}")]
        public async Task<IActionResult> GetInvoiceByIdRequest([FromRoute] int invoiceId)
        {
            var request = new GetInvoiceByIdRequest()
            {
                Id = invoiceId
            };
            return await this.HandleRequest<GetInvoiceByIdRequest, GetInvoiceByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceRequest request)
        {
            return await this.HandleRequest<CreateInvoiceRequest, CreateInvoiceResponse>(request);
        }

        [HttpPut]
        [Route("{invoiceId}")]
        public async Task<IActionResult> UpdateInvoiceById([FromRoute] int invoiceId, [FromBody] UpdateInvoiceByIdRequest request)
        {
            request.Id = invoiceId;
            return await this.HandleRequest<UpdateInvoiceByIdRequest, UpdateInvoiceByIdResponse>(request);
        }


        [HttpDelete]
        [Route("{invoiceId}")]
        public async Task<IActionResult> DeleteInvoiceById([FromRoute] int invoiceId)
        {
            var request = new DeleteInvoiceByIdRequest()
            {
                Id = invoiceId
            };
            return await this.HandleRequest<DeleteInvoiceByIdRequest, DeleteInvoiceByIdResponse>(request);
        }

    }
}
