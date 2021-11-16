using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using MediatR;
using System;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices
{
    public class UpdateLaundryByIdRequest : RequestBase,IRequest<UpdateLaundryResponse>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LaundryId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime RecievedDate { get; set; }
        public DateTime? IssuedDate { get; set; }
        public bool IsFinished { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalNetto { get; set; }
        public decimal TotalBrutto { get; set; }
        public double TotalServiceWeight { get; set; }
    }
}
