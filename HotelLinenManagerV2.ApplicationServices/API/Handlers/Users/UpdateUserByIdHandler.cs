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
    public class UpdateUserByIdHandler : IRequestHandler<UpdateUserByIdRequest, UpdateUserByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IPasswordHasher passwordHasher;

        public UpdateUserByIdHandler(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IMapper mapper, IPasswordHasher passwordHasher)
        {
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public async Task<UpdateUserByIdResponse> Handle(UpdateUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
               Id = request.Id
            };

            var user = await this.queryExecutor.Execute(query);
            if (user == null)
            {
                return new UpdateUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };

            }

            var auth = passwordHasher.Hash(request.Password);
            request.Password = auth[0];
            request.Salt = auth[1];

            var mappedUser = this.mapper.Map<User>(request);
            var command = new UpdateUserCommand()
            {
                Parameter = mappedUser
            };
            var createdUser = await this.commandExecutor.Execute(command);

            return new UpdateUserByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(createdUser)
            };
        }
    }
}