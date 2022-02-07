using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagerV2.ApplicationServices.Components.NullOrEmptyCheker
{
    public class NullOrEmptyChecker : INullOrEmptyChecker
    {
        public bool IsEmptyOrNull(string name, string city, string street)
        {
            if (string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(city)
                || string.IsNullOrEmpty(street)) return true;
            return false;
        }
    }
}
