using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.PriceListDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class PriceListDetailsProfile : Profile
    {
        public PriceListDetailsProfile()
        {
            CreateMap<DataAccess.Entities.PriceListDetail, PriceListDetail>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.HotelLinenId, y => y.MapFrom(z => z.HotelLinenId))
                .ForMember(x => x.TaxValue, y => y.MapFrom(z => z.TaxValue))
                .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg))
                .ForMember(x => x.HotelLinen, y => y.MapFrom(z => z.HotelLinen));

            CreateMap<CreatePriceListDetailRequest,DataAccess.Entities.PriceListDetail>()
              .ForMember(x => x.HotelLinenId, y => y.MapFrom(z => z.HotelLinenId))
              .ForMember(x => x.TaxValue, y => y.MapFrom(z => z.TaxValue))
              .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg));

            CreateMap<UpdatePriceListDetailsRequest,DataAccess.Entities.PriceListDetail>()
              .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
              .ForMember(x => x.HotelLinenId, y => y.MapFrom(z => z.HotelLinenId))
              .ForMember(x => x.TaxValue, y => y.MapFrom(z => z.TaxValue))
              .ForMember(x => x.PricePerKg, y => y.MapFrom(z => z.PricePerKg));

            CreateMap<DeletePriceListDetailsRequest,DataAccess.Entities.PriceListDetail>()
              .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
          
        }
    }
}
