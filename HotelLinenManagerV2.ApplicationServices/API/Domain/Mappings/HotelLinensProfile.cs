using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinens;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class HotelLinensProfile : Profile
    {
        public HotelLinensProfile()
        {
            this.CreateMap<HotelLinenManagerV2.DataAccess.Entities.HotelLinen, HotelLinen>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                 .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                 .ForMember(x => x.Color, y => y.MapFrom(z => z.Color))
                 .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                 .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount));

            this.CreateMap<CreateHotelLinenRequest, DataAccess.Entities.HotelLinen>()
                 .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                 .ForMember(x => x.Color, y => y.MapFrom(z => z.Color))
                 .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                 .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount));

            this.CreateMap<UpdateHotelLinenByIdRequest, DataAccess.Entities.HotelLinen>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                 .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                 .ForMember(x => x.Color, y => y.MapFrom(z => z.Color))
                 .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                 .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount));

            //this.CreateMap<PatchHotelLinenByIdRequest, DataAccess.Entities.HotelLinen>()
            //     .ForMember(x => x.Id, y => y.MapFrom(z => z.id))
            //     .ForMember(x => x.NameWithShortDescription, y => y.MapFrom(z => z.NameWithShortDescription))
            //     .ForMember(x => x.Color, y => y.MapFrom(z => z.Color))
            //     .ForMember(x => x.HotelLinenTypeId, y => y.MapFrom(z => z.HotelLinenTypeId))
            //     .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
            //     .ForMember(x => x.WarehauseId, y => y.MapFrom(z => z.WarehauseId));


            this.CreateMap<DeleteHotelLinenByIdRequest, DataAccess.Entities.HotelLinen>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));



        }
    }
}
