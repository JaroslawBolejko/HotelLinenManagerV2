using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class HotelLinensProfile : Profile
    {
        public HotelLinensProfile()
        {
            this.CreateMap<HotelLinenManagerV2.DataAccess.Entities.HotelLinen, HotelLinen>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                 .ForMember(x => x.NameWithShortDescription, y => y.MapFrom(z => z.NameWithShortDescription))
                 .ForMember(x => x.HotelLinenTypeId, y => y.MapFrom(z => z.HotelLinenTypeId));

            //this.CreateMap<CreateHotelLinenRequest, DataAccess.Entities.HotelLinen>()
            //     .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            //     .ForMember(x => x.NameWithShortDescription, y => y.MapFrom(z => z.NameWithShortDescription))
            //     .ForMember(x => x.HotelLinenTypeId, y => y.MapFrom(z => z.HotelLinenTypeId));

            //this.CreateMap<PutHotelLinenRequest, DataAccess.Entities.HotelLinen>()
            //     .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            //     .ForMember(x => x.NameWithShortDescription, y => y.MapFrom(z => z.NameWithShortDescription))
            //     .ForMember(x => x.HotelLinenTypeId, y => y.MapFrom(z => z.HotelLinenTypeId));


            //this.CreateMap<DeleteHotelLinenByIdRequest, DataAccess.Entities.HotelLinen>()
            //     .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
         

        }
    }
}
