using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
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
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Users");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetALLUsers([FromQuery] GetAllUsersRequest request)
        {
            return await this.HandleRequest<GetAllUsersRequest, GetAllUsersResponse>(request);
        }

        [HttpGet]
        [Route("{me}")]
        public async Task<IActionResult> GetUserMe([FromRoute] string me)
        {
            var request = new GetUserMeRequest()
            {
                Me = me
            };
            return await this.HandleRequest<GetUserMeRequest, GetUserMeResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            return await this.HandleRequest<CreateUserRequest, CreateUserResponse>(request);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUserById([FromRoute] int id, [FromBody] UpdateUserByIdRequest request)
        {
            request.Id = id;
            return await this.HandleRequest<UpdateUserByIdRequest, UpdateUserByIdResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var request = new DeleteUserByIdRequest()
            {
                Id = id
            };
            return await this.HandleRequest<DeleteUserByIdRequest, DeleteUserByIdResponse>(request);
        }


    }
}
