using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies;
using HotelLinenManagerV2.ApplicationServices.Components.GUSDataConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class FromGUSProfile : Profile
    {
        public FromGUSProfile()
        {
            this.CreateMap<RootDaneSzukajPodmioty, CreateCompanyRequest>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Dane.Nazwa))
                .ForMember(x => x.City, y => y.MapFrom(z => z.Dane.Miejscowosc))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Dane.Ulica))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Dane.NrNieruchomosci))
                .ForMember(x => x.ApartmentNumber, y => y.MapFrom(z => z.Dane.NrLokalu))
                .ForMember(x => x.ZipCode, y => y.MapFrom(z => z.Dane.KodPocztowy));
            
        }
    }
}
