using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Warehauses;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Warehauses;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.Warehauses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Warehauses
{
    public class CreateWarehauseHandler : IRequestHandler<CreateWarehauseRequest, CreateWarehauseResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public CreateWarehauseHandler(ICommandExecutor commandExecutor,IQueryExecutor queryExecutor ,IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateWarehauseResponse> Handle(CreateWarehauseRequest request, CancellationToken cancellationToken)
        {
            var query = new GetWarehausesQuery()
            {
              WarehauseNumber=request.WarehauseNumber,
              CompanyId = request.CompanyId
            };
            var getWarhause = await this.queryExecutor.Execute(query);
            if(getWarhause!=null)
            {
                return new CreateWarehauseResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict + " Magazyn o podanym numerze już istnieje")
                };
            }
            var mappedWarehause = this.mapper.Map<DataAccess.Entities.Warehause>(request);
            var command = new CreateWarehauseCommand()
            {
                Parameter = mappedWarehause
            };
            var wareHauseFromDB = await this.commandExecutor.Execute(command);
            return new CreateWarehauseResponse()
            {
                Data = this.mapper.Map<Domain.Models.Warehause>(wareHauseFromDB)
            };
        }
    }
}
