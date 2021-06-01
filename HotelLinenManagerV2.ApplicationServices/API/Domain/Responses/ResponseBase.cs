using HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Responses
{
    public class ResponseBase<T> : ErrorResponseBase
    {
        public T Data { get; set; } 
    }
}
