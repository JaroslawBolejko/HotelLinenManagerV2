using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class LaundryServicesProfile : Profile
    {
        public LaundryServicesProfile()
        {
            this.CreateMap<DataAccess.Entities.LaundryService, LaundryService>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
               .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
               .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
               .ForMember(x => x.RecievedDate, y => y.MapFrom(z => z.RecievedDate))
               .ForMember(x => x.IssuedDate, y => y.MapFrom(z => z.IssuedDate))
               .ForMember(x => x.IssuedDate, y => y.MapFrom(z => z.IssuedDate))
               .ForMember(x => x.IsFinished, y => y.MapFrom(z => z.IsFinished));

            this.CreateMap<CreateLaundryRequest, DataAccess.Entities.LaundryService>()
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
               .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
               .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
               .ForMember(x => x.RecievedDate, y => y.MapFrom(z => z.RecievedDate))
               .ForMember(x => x.IssuedDate, y => y.MapFrom(z => z.IssuedDate))
               .ForMember(x => x.IsFinished, y => y.MapFrom(z => z.IsFinished));


            this.CreateMap<UpdateLaundryByIdRequest, DataAccess.Entities.LaundryService>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
               .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
               .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
               .ForMember(x => x.RecievedDate, y => y.MapFrom(z => z.RecievedDate))
               .ForMember(x => x.IssuedDate, y => y.MapFrom(z => z.IssuedDate))
               .ForMember(x => x.IsFinished, y => y.MapFrom(z => z.IsFinished));


            this.CreateMap<DeleteLaundryByIdRequest, DataAccess.Entities.LaundryService>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

        }
    }
}
