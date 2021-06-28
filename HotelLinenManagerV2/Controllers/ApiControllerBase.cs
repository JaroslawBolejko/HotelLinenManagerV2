using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger logger;

        protected ApiControllerBase(IMediator mediator, ILogger logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }
        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {

                return this.BadRequest(
                         this.ModelState
                         .Where(x => x.Value.Errors.Any())
                         .Select(x => new { property = x.Key, errors = x.Value.Errors }));

            }
            var username = this.User.FindFirstValue(ClaimTypes.Name);
            if (User.Claims.FirstOrDefault() != null)
            {
                (request as RequestBase).AuthenticationName = this.User.FindFirstValue(ClaimTypes.Name);
                (request as RequestBase).AuthenticationRole = this.User.FindFirstValue(ClaimTypes.Role);
                (request as RequestBase).AuthenticationCompanyId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            var response = await this.mediator.Send(request);
            if (response.Error != null)
            {

                return this.ErrorResopnse(response.Error);
            }

            return this.Ok(response);
        }

        private IActionResult ErrorResopnse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            logger.LogError($"An Error occured :{(int)httpCode} {httpCode.ToString()}");
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            return errorType switch
            {
                ErrorType.InternalServerError => HttpStatusCode.InternalServerError,
                ErrorType.Forbidden => HttpStatusCode.Forbidden,
                ErrorType.Unauthorized => HttpStatusCode.Unauthorized,
                ErrorType.NotFound => HttpStatusCode.NotFound,
                ErrorType.UnsupportedMediaType => HttpStatusCode.UnsupportedMediaType,
                ErrorType.UnsupportedMethod => HttpStatusCode.MethodNotAllowed,
                ErrorType.RequestTooLarge => HttpStatusCode.RequestEntityTooLarge,
                ErrorType.TooManyRequests => HttpStatusCode.TooManyRequests,
                ErrorType.Conflict => HttpStatusCode.Conflict,
                _ => HttpStatusCode.BadRequest,
            };
        }
    }
}
