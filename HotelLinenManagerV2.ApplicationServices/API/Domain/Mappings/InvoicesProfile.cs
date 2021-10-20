using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Invoices;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<DataAccess.Entities.Invoice, Invoice>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
                .ForMember(x => x.DateOfInvoice, y => y.MapFrom(z => z.DateOfInvoice))
                .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
                .ForMember(x => x.TotalCost, y => y.MapFrom(z => z.TotalCost))
                .ForMember(x => x.IsPaid, y => y.MapFrom(z => z.IsPaid))
                .ForMember(x => x.LaundryServices, y => y.MapFrom(z => z.LaundryServices));

            CreateMap<CreateInvoiceRequest, DataAccess.Entities.Invoice>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
                .ForMember(x => x.DateOfInvoice, y => y.MapFrom(z => z.DateOfInvoice))
                .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
                .ForMember(x => x.TotalCost, y => y.MapFrom(z => z.TotalCost))
                .ForMember(x => x.IsPaid, y => y.MapFrom(z => z.IsPaid));

            CreateMap<UpdateInvoiceByIdRequest, DataAccess.Entities.Invoice>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
                .ForMember(x => x.DateOfInvoice, y => y.MapFrom(z => z.DateOfInvoice))
                .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
                .ForMember(x => x.TotalCost, y => y.MapFrom(z => z.TotalCost))
                .ForMember(x => x.IsPaid, y => y.MapFrom(z => z.IsPaid));

            CreateMap<DeleteInvoiceByIdRequest, DataAccess.Entities.Invoice>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));



        }
    }
}
