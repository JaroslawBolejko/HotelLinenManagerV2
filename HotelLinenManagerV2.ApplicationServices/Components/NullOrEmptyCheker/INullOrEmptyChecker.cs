using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagerV2.ApplicationServices.Components.NullOrEmptyCheker
{
   public interface INullOrEmptyChecker
    {
        public bool IsEmptyOrNull<T>(T parameter1, T prameter2, T parameter3);
    }
}
