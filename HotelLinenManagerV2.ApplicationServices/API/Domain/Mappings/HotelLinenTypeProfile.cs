using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.HotelLinenTypes;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class HotelLinenTypeProfile : Profile
    {
        public HotelLinenTypeProfile()
        {
            this.CreateMap<DataAccess.Entities.HotelLinenType, HotelLinenType>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.TypeName, y => y.MapFrom(z => z.TypeName))
                .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
                .ForMember(x => x.Weight, y => y.MapFrom(z => z.Weight))
                .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg))
                .ForMember(x => x.Tax, y => y.MapFrom(z => z.Tax))
                .ForMember(x => x.HotelLinens, y => y.MapFrom(z => z.HotelLinens));

            this.CreateMap<CreateLinenTypeRequest,DataAccess.Entities.HotelLinenType>()
                 .ForMember(x => x.TypeName, y => y.MapFrom(z => z.TypeName))
                 .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
                 .ForMember(x => x.Weight, y => y.MapFrom(z => z.Weight))
                 .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg))
                 .ForMember(x => x.Tax, y => y.MapFrom(z => z.Tax));

            this.CreateMap<UpdateLinenTypeByIdRequest, DataAccess.Entities.HotelLinenType>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                 .ForMember(x => x.TypeName, y => y.MapFrom(z => z.TypeName))
                 .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
                 .ForMember(x => x.Weight, y => y.MapFrom(z => z.Weight))
                 .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg))
                 .ForMember(x => x.Tax, y => y.MapFrom(z => z.Tax));

            this.CreateMap<DeleteLinenTypeByIdRequest, DataAccess.Entities.HotelLinenType>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

        }
    }
}
