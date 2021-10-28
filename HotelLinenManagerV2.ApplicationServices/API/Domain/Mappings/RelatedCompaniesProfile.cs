using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.RelatedCompanies;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class RelatedCompaniesProfile : Profile
    {
        public RelatedCompaniesProfile()
        {
            CreateMap<DataAccess.Entities.RelatedCompany, RelatedCompany>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId))
                .ForMember(x => x.Company, y => y.MapFrom(z => z.Company))
                .ForMember(x => x.Laundry, y => y.MapFrom(z => z.Laundry));

            CreateMap<CreateRelatedCompanyRequest, DataAccess.Entities.RelatedCompany>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.LaundryId, y => y.MapFrom(z => z.LaundryId));

            CreateMap<DeleteRelatedCompanyRequest, DataAccess.Entities.RelatedCompany>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

        }
    }
}
