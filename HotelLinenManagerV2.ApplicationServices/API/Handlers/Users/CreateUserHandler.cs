using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
using HotelLinenManagerV2.ApplicationServices.Components.PasswordHasher;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Users;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Users;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static HotelLinenManagerV2.DataAccess.Entities.User;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IPasswordHasher passwordHasher;

        public CreateUserHandler(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IMapper mapper, IPasswordHasher passwordHasher)
        {
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                CompanyId = request.CompanyId,
                Username = request.Username
            };

            var user = await this.queryExecutor.Execute(query);
            if(user!=null)
            {
                return new CreateUserResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };

            }

            var auth = passwordHasher.Hash(request.Password);
            request.Password = auth[0];
            request.Salt = auth[1];

            
            var mappedUser = this.mapper.Map<User>(request);
            var command = new CreateUserCommand()
            {
                Parameter = mappedUser
            };
            var createdUser = await this.commandExecutor.Execute(command);

            return new CreateUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(createdUser)
            };
        }
    }
}
