using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using HotelLinenManagerV2.ApplicationServices.Components.DocNumCreator;
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
        private readonly IDocNumCreator docNumCreator;
        private string lastDocNumber;

        public CreateLaundryServiceHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper, IDocNumCreator docNumCreator)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
            this.docNumCreator = docNumCreator;
        }

        public async Task<CreateLaundryResponse> Handle(CreateLaundryRequest request, CancellationToken cancellationToken)
        {

            // Coś mi sie wydaje że nie koniecznie musze dostawać ostanie pranie , pomyśl nad innym rozwiązaniem
            var query = new GetLaundryQuery()
            {
                CompanyId = request.AuthenticationCompanyId,
                LaundryId = request.LaundryId,
                WouldLikeToCreate = true
            };
            var lastLaundry = await this.queryExecutor.Execute(query);
            if (lastLaundry != null)
            {
                lastDocNumber = lastLaundry.Number;
            }
            else
            {
                lastDocNumber = "0/0/0";
            }
            request.Number = docNumCreator.DocumentNumberCreator(lastDocNumber);

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