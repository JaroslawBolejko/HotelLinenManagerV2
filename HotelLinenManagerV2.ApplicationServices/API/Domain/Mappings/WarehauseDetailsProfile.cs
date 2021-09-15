using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.WarehauseDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class WarehauseDetailsProfile : Profile
    {
        public WarehauseDetailsProfile()
        {
            this.CreateMap<DataAccess.Entities.WarehauseDetail, WarehauseDetail>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.HotelLinenId, y => y.MapFrom(z => z.HotelLinenId))
                .ForMember(x => x.WarehauseId, y => y.MapFrom(z => z.WarehauseId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
              .ForMember(x => x.HotelLinenName, y => y.MapFrom(z => z.HotelLinen.Description))
              .ForMember(x => x.HotelLinenType, y => y.MapFrom(z => z.HotelLinen.TypeName))
              .ForMember(x => x.Color, y => y.MapFrom(z => z.HotelLinen.Color));
                

            this.CreateMap<CreateDetailsRequest,DataAccess.Entities.WarehauseDetail>()
                .ForMember(x => x.HotelLinenId, y => y.MapFrom(z => z.HotelLinenId))
                .ForMember(x => x.WarehauseId, y => y.MapFrom(z => z.WarehauseId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount));

            this.CreateMap<UpdateDetailsRequest, DataAccess.Entities.WarehauseDetail>()
                .ForMember(x=>x.Id,y=>y.MapFrom(z=>z.Id))
                .ForMember(x => x.HotelLinenId, y => y.MapFrom(z => z.HotelLinenId))
                .ForMember(x => x.WarehauseId, y => y.MapFrom(z => z.WarehauseId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount));

            this.CreateMap<DeleteDetailsByIdRequest, DataAccess.Entities.WarehauseDetail>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
              

        }
    }
}
