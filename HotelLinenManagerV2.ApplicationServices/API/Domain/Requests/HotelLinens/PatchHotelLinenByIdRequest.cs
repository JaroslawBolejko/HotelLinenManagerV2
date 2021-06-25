using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.HotelLinens;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens
{
    public class PatchHotelLinenByIdRequest : RequestBase, IRequest<PatchHotelLinenByIdResponse>
    {
        public int Id { get; set; }
        public JsonPatchDocument<HotelLinen> LinenUpdate { get; set; }
       
    }
}
