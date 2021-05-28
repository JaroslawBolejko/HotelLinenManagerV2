using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.Companies;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.Companies
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public CreateCompanyHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            var mappedCommand = this.mapper.Map<Company>(request);
            var command = new CreateCompanyCommand()
            {
                Parameter = mappedCommand
            };
            var createdCompany = await this.commandExecutor.Execute(command);
            var response = new CreateCompanyResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Company>(createdCompany)
            };
            return response;
        }
    }
}
