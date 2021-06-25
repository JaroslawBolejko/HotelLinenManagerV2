using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator, logger)
        {

        }

        [HttpGet]
        [Route("{me}")]
        public async Task<IActionResult> GetUsers([FromRoute] string me)
        {
            var request = new GetUserMeRequest()
            {
                Me = me
            };
            return await this.HandleRequest<GetUserMeRequest, GetUserMeResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            return await this.HandleRequest<CreateUserRequest, CreateUserResponse>(request);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> deleteUser([FromRoute] int id)
        {
            var request = new DeleteUserByIdRequest()
            {
                Id = id
            };
            return await this.HandleRequest<DeleteUserByIdRequest, DeleteUserByIdResponse>(request);
        }


    }
}
