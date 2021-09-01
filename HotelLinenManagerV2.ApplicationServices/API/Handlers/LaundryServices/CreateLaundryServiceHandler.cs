using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.LaundryServices;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.LaundryServices;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.LaundryServiceDetails
{
    public class CreateLaundryServiceHandler : IRequestHandler<CreateLaundryRequest, CreateLaundryResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public CreateLaundryServiceHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateLaundryResponse> Handle(CreateLaundryRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllLaundryQuery()
            {
                //Number=request.Number
            };

            var details = await this.queryExecutor.Execute(query);

            if (details != null)
            {
                return new CreateLaundryResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }

            var mappedDetails = this.mapper.Map<DataAccess.Entities.LaundryService>(request);
            var command = new CreateLaundryCommand()
            {
                Parameter = mappedDetails
            };

            var detailsFromDB = await this.commandExecutor.Execute(command);
            return new CreateLaundryResponse()
            {
                Data = this.mapper.Map<Domain.Models.LaundryService>(detailsFromDB)
            };
        }
    }
}