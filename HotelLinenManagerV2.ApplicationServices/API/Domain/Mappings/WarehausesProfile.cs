using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Warehauses;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class WarehausesProfile : Profile
    {
        public WarehausesProfile()
        {
            this.CreateMap<HotelLinenManagerV2.DataAccess.Entities.Warehause, Warehause>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.WarehauseType, y => y.MapFrom(z => z.WarehauseType))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.WarehauseNumber, y => y.MapFrom(z => z.WarehauseNumber))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.WarehauseDetails, y => y.MapFrom(z => z.WarehauseDetails));

            this.CreateMap<CreateWarehauseRequest, DataAccess.Entities.Warehause>()
                .ForMember(x => x.WarehauseType, y => y.MapFrom(z => z.WarehauseType))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.WarehauseNumber, y => y.MapFrom(z => z.WarehauseNumber))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId));
                //.ForMember(x => x.WarehauseDetails, y => y.MapFrom(z => z.WarehauseDetails));


            this.CreateMap<UpdateWarehauseByIdRequest, DataAccess.Entities.Warehause>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                 .ForMember(x => x.WarehauseType, y => y.MapFrom(z => z.WarehauseType))
                 .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                 .ForMember(x => x.WarehauseNumber, y => y.MapFrom(z => z.WarehauseNumber))
                 .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId));

            this.CreateMap<DeleteWarehauseByIdRequest, DataAccess.Entities.Warehause>()
             .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

        }
    }
}
