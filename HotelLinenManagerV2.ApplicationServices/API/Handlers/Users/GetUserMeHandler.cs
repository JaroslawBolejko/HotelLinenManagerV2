using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Users;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Users
{
    public class GetUserMeHandler : IRequestHandler<GetUserMeRequest, GetUserMeResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetUserMeHandler(IQueryExecutor queryExecutor,IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetUserMeResponse> Handle(GetUserMeRequest request, CancellationToken cancellationToken)
        {
            if (request.Me == "Me" || request.Me == "me")
            {
                var query = new GetUserQuery()
                {
                      Username = request.AuthenticationName

                };

                var user = await this.queryExecutor.Execute(query);
                if (user == null)
                {
                    return new GetUserMeResponse()
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                var mappedUser = this.mapper.Map<User>(user);

                return new GetUserMeResponse()
                {
                    Data = mappedUser
                };
            }
            return new GetUserMeResponse()
            {
                Error = new ErrorModel(ErrorType.UnsupportedMethod)
            };
        }
    }
}
