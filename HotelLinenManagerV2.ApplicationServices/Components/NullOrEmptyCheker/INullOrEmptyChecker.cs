using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagerV2.ApplicationServices.Components.NullOrEmptyCheker
{
   public interface INullOrEmptyChecker
    {
        public bool IsEmptyOrNull(string name, string city, string street);
    }
}
