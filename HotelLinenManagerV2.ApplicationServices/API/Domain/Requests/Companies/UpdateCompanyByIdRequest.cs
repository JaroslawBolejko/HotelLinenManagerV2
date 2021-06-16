using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.Companies;
using HotelLinenManagerV2.DataAccess.Entities;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Companies
{
    public class UpdateCompanyByIdRequest : IRequest<UpdateCompanyByIdResponse>
    {
        public int id;
        public CompanyType Type { get; set; }
        public string Name { get; set; }

        public string TaxNumber { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }
        public ushort ApartmentNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }
        public string Email { get; set; }
        public string TelefonNumber { get; set; }
    }
}
