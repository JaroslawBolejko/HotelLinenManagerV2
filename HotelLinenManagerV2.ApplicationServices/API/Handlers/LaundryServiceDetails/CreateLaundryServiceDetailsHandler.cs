using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServiceDetails;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServiceDetails;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.LaundryServiceDetails;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelLinenManagerV2.DataAccess.CQRS;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.LaundryServiceDetails
{
    public class CreateLaundryServiceDetailsHandler : IRequestHandler<CreateLaundryDetailsRequest, CreateLaundryDetailsResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public CreateLaundryServiceDetailsHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateLaundryDetailsResponse> Handle(CreateLaundryDetailsRequest request, CancellationToken cancellationToken)
        {
            

            var query = new GetAllLaundryDetailsQuery()
            {
                          
            };

            var details = await this.queryExecutor.Execute(query);

            if (details != null)
            {
                return new CreateLaundryDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }

            var mappedDetails = this.mapper.Map<DataAccess.Entities.LaundryServiceDetail>(request);
            var command = new CreateLaundryDetailCommand()
            {
                Parameter = mappedDetails
            };

            var detailsFromDB = await this.commandExecutor.Execute(command);
            return new CreateLaundryDetailsResponse()
            {
                Data = this.mapper.Map<Domain.Models.LaundryServiceDetail>(detailsFromDB)
            };
        }
    }
}