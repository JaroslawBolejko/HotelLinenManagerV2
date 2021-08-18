using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServiceDetails;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class LaundryServiceDetailsProfile : Profile
    {
        public LaundryServiceDetailsProfile()
        {
            this.CreateMap<DataAccess.Entities.LaundryServiceDetail, LaundryServiceDetail>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LaundryServiceId, y => y.MapFrom(z => z.LaundryServiceId))
                .ForMember(x => x.HotelLinenId, y => y.MapFrom(z => z.HotelLinenId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount));

            this.CreateMap<CreateLaundryDetailsRequest, DataAccess.Entities.LaundryServiceDetail>()
                .ForMember(x => x.LaundryServiceId, y => y.MapFrom(z => z.LaundryServiceId))
                .ForMember(x => x.HotelLinenId, y => y.MapFrom(z => z.HotelLinenId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount));

            this.CreateMap<UpdateLaundryDetailsRequest, DataAccess.Entities.LaundryServiceDetail>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LaundryServiceId, y => y.MapFrom(z => z.LaundryServiceId))
                .ForMember(x => x.HotelLinenId, y => y.MapFrom(z => z.HotelLinenId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount));

            this.CreateMap<DeleteLaundryDetailsByIdRequest, DataAccess.Entities.LaundryServiceDetail>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

        }
    }
}
