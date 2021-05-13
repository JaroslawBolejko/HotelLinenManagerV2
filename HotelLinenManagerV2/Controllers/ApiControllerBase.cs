//using HotelLinenManagement.ApplicationServices.API.Domain;
//using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Linq;
//using System.Net;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace HotelLinenManagement.Controllers
//{
//    public abstract class ApiControllerBase : ControllerBase
//    {
//        private readonly IMediator mediator;
//        private readonly ILogger logger;

//        protected ApiControllerBase(IMediator mediator, ILogger logger)
//        {
//            this.mediator = mediator;
//            this.logger = logger;
//        }
//        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
//            where TRequest : IRequest<TResponse>
//            where TResponse : ErrorResponseBase
//        {
//            if (!this.ModelState.IsValid)
//            {
//                return this.BadRequest(
//                         this.ModelState
//                         .Where(x => x.Value.Errors.Any())
//                         .Select(x => new { property = x.Key, errors = x.Value.Errors }));
//            }
//            //      var username = this.User.FindFirstValue(ClaimTypes.Name);
//            if (User.Claims.FirstOrDefault() != null)
//                //{
//                (request as RequestBase).AuthenticationName = this.User.FindFirstValue(ClaimTypes.Name);
//            //    //(request as RequestBase).AuthenticationRole = (AppRole)Enum.Parse(typeof(AppRole), this.User.FindFirstValue(ClaimTypes.Role));
//            (request as RequestBase).AuthenticationRole = this.User.FindFirstValue(ClaimTypes.Role);
//            //    (request as RequestBase).AuthenticationId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
//            //}

//            var response = await this.mediator.Send(request);
//            if (response.Error != null)
//            {
//                //Logowanie błedów w dobym miejscu, poprawić żeby pojawiałe się uszczegółowiony błąd
//                logger.LogError("An error Occured ");
//                return this.ErrorResopnse(response.Error);
//            }

//            return this.Ok(response);
//        }

//        private IActionResult ErrorResopnse(ErrorModel errorModel)
//        {
//            var httpCode = GetHttpStatusCode(errorModel.Error);
//            return StatusCode((int)httpCode, errorModel);
//        }

//        private static HttpStatusCode GetHttpStatusCode(string errorType)
//        {
//            switch (errorType)
//            {
//                case ErrorType.InternalServerError:
//                    return HttpStatusCode.InternalServerError;
//                //case ErrorType.ValidationError:
//                //    return HttpStatusCode.Validation;
//                //case ErrorType.NotAuthenticated:
//                //    return HttpStatusCode.NotAuthenticated;
//                case ErrorType.Unauthorized:
//                    return HttpStatusCode.Unauthorized;
//                case ErrorType.NotFound:
//                    return HttpStatusCode.NotFound;
//                case ErrorType.UnsupportedMediaType:
//                    return HttpStatusCode.UnsupportedMediaType;
//                case ErrorType.UnsupportedMethod:
//                    return HttpStatusCode.MethodNotAllowed;
//                case ErrorType.RequestTooLarge:
//                    return HttpStatusCode.RequestEntityTooLarge;
//                case ErrorType.TooManyRequests:
//                    return HttpStatusCode.TooManyRequests;
//                case ErrorType.Conflict:
//                    return HttpStatusCode.Conflict;
//                default:
//                    return HttpStatusCode.BadRequest;
//            }
//        }
//    }
//}
