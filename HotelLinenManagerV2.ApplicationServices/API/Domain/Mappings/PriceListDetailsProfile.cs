using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class PriceListDetailsProfile : Profile
    {
        public PriceListDetailsProfile()
        {
            CreateMap<DataAccess.Entities.PriceListDetail, PriceListDetail>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.TaxValue, y => y.MapFrom(z => z.TaxValue))
                .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg))
                .ForMember(x => x.PriceListId, y => y.MapFrom(z => z.PriceListId))
                .ForMember(x => x.LinenType, y => y.MapFrom(z => z.LinenType));


            CreateMap<CreatePriceListDetailRequest, DataAccess.Entities.PriceListDetail>()
              .ForMember(x => x.PriceListId, y => y.MapFrom(z => z.PriceListId))
              .ForMember(x => x.TaxValue, y => y.MapFrom(z => z.TaxValue))
              .ForMember(x => x.LinenType, y => y.MapFrom(z => z.LinenType))
              .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg));

            CreateMap<UpdatePriceListDetailsRequest, DataAccess.Entities.PriceListDetail>()
              .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
              .ForMember(x => x.PriceListId, y => y.MapFrom(z => z.PriceListId))
              .ForMember(x => x.TaxValue, y => y.MapFrom(z => z.TaxValue))
              .ForMember(x => x.LinenType, y => y.MapFrom(z => z.LinenType))
              .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg));

            CreateMap<DeletePriceListDetailsRequest, DataAccess.Entities.PriceListDetail>()
              .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

        }
    }
}
