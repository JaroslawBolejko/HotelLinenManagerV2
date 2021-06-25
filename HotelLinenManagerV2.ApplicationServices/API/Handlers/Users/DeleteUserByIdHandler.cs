using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Users;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Users;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Users
{
    public class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdRequest, DeleteUserByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteUserByIdHandler(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteUserByIdResponse> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Id = request.Id
            };
            var id = await queryExecutor.Execute(query);

            if (id == null)
            {
                return new DeleteUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var user = this.mapper.Map<User>(request);

            var command = new DeleteUserByIdCommand()
            {
                Parameter = user
            };
            var userFromDB = await this.commandExecutor.Execute(command);

            return new DeleteUserByIdResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.User>(userFromDB)
            };
        }
    }
}
