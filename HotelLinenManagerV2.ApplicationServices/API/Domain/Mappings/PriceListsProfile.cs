using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceLists;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class PriceListsProfile : Profile
    {
        public PriceListsProfile()
        {
            CreateMap<DataAccess.Entities.PriceList, PriceList>()
                .ForMember(x=>x.Id, y=>y.MapFrom(z=>z.Id))
                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId))
                .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg))
                .ForMember(x => x.TaxValue, y => y.MapFrom(z => z.TaxValue))
                .ForMember(x => x.HotelLinens, y => y.MapFrom(z => z.HotelLinens))
                .ForMember(x => x.Laundry, y => y.MapFrom(z => z.Laundry));

            CreateMap<CreatePriceListRequest, DataAccess.Entities.PriceList>()
                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId))
                .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg))
                .ForMember(x => x.TaxValue, y => y.MapFrom(z => z.TaxValue));


            CreateMap<UpdatePriceListByIdRequest, DataAccess.Entities.PriceList>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId))
               .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg))
               .ForMember(x => x.TaxValue, y => y.MapFrom(z => z.TaxValue));
               

            CreateMap<DeletePriceListByIdRequest, DataAccess.Entities.PriceList>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
        }
    }
}
