using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            this.CreateMap<DataAccess.Entities.Company, API.Domain.Models.Company>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
                .ForMember(x => x.ZipCode, y => y.MapFrom(z => z.ZipCode))
                .ForMember(x => x.TaxNumber, y => y.MapFrom(z => z.TaxNumber))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number));

            this.CreateMap<CreateCompanyRequest,DataAccess.Entities.Company>()
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
                .ForMember(x => x.ZipCode, y => y.MapFrom(z => z.ZipCode))
                .ForMember(x => x.TaxNumber, y => y.MapFrom(z => z.TaxNumber))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number));

            this.CreateMap<UpdateCompanyByIdRequest, DataAccess.Entities.Company>()
                .ForMember(x=>x.Id,y=>y.MapFrom(z=>z.id))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
                .ForMember(x => x.ZipCode, y => y.MapFrom(z => z.ZipCode))
                .ForMember(x => x.TaxNumber, y => y.MapFrom(z => z.TaxNumber))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number));

            this.CreateMap<DeleteCompanyByIdRequest, DataAccess.Entities.Company>()
              .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
        }
    }
}
