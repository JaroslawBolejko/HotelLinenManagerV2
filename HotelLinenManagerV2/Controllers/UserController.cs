using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [Route("username")]
        public async Task<IActionResult> GetUsers([FromRoute] string username)
        {
            var request = new GetUserByUsernameRequest()
            {
                Username = username
            };
            return await this.HandleRequest<GetUserByUsernameRequest, GetUserByUsernameResponse>(request);
        }




    }
}
