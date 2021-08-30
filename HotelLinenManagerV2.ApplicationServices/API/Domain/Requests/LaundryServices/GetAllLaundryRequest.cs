using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses.LaundryServices;
using MediatR;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.LaundryServices
{
    public class GetAllLaundryRequest : RequestBase,IRequest<GetAllLaundryResponse>
    {
        public string Number { get; set; }

       // const int maxPageSize = 10;
       //public int PageNumber { get; set; } = 1;
       // private int pageSize = 5;
       // public int PageSize
       // {
       //     get
       //     {
       //         return this.pageSize;
       //     }
       //     set
       //     {
       //         this.pageSize = (value > maxPageSize) ? maxPageSize : value;
       //     }
       // }

    }
}
