﻿using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.PriceListDetails;
using HotelLinenManagerV2.DataAccess.CQRS;
using HotelLinenManagerV2.DataAccess.CQRS.Commands.PriceListDetails;
using HotelLinenManagerV2.DataAccess.CQRS.Queries.PriceListDetails;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Handlers.PriceListDetails
{
    public class UpdatePriceListDetailsHandler : IRequestHandler<UpdatePriceListDetailsRequest, UpdatePriceListDetailsResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public UpdatePriceListDetailsHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async  Task<UpdatePriceListDetailsResponse> Handle(UpdatePriceListDetailsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPriceListDetailsQuery()
            {
                Id = request.Id
            };
            var prices = await this.queryExecutor.Execute(query);
            if (prices == null)
            {
                return new UpdatePriceListDetailsResponse()
                {
                    Error = new Domain.ErrorHandling.ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedPrices = this.mapper.Map<PriceListDetail>(request);
            var command = new UpdatePriceListDetailsCommand()
            {
                Parameter = mappedPrices
            };
            var updatedPriceList = await this.commandExecutor.Execute(command);
            return new UpdatePriceListDetailsResponse()
            {
                Data = this.mapper.Map<Domain.Models.PriceListDetail>(updatedPriceList)
            };
        }
    }
}
