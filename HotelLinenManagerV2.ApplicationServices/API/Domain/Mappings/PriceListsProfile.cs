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
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.DocName))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.DocNumber))
                .ForMember(x => x.CreationDate, y => y.MapFrom(z => z.CreationDate))
                .ForMember(x => x.IsCurrent, y => y.MapFrom(z => z.IsCurrent))
                .ForMember(x => x.Laundry, y => y.MapFrom(z => z.Laundry))
                .ForMember(x => x.Company, y => y.MapFrom(z => z.Company))
                .ForMember(x => x.Details, y => y.MapFrom(z => z.Details));

            CreateMap<CreatePriceListRequest, DataAccess.Entities.PriceList>()

                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.DocName, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.DocNumber, y => y.MapFrom(z => z.Number))
                .ForMember(x => x.IsCurrent, y => y.MapFrom(z => z.IsCurrent))
                .ForMember(x => x.CreationDate, y => y.MapFrom(z => z.CreationDate));


            CreateMap<UpdatePriceListByIdRequest, DataAccess.Entities.PriceList>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.DocName, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.DocNumber, y => y.MapFrom(z => z.Number))
                .ForMember(x => x.IsCurrent, y => y.MapFrom(z => z.IsCurrent))
                .ForMember(x => x.CreationDate, y => y.MapFrom(z => z.CreationDate));



            CreateMap<DeletePriceListByIdRequest, DataAccess.Entities.PriceList>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
        }
    }
}
