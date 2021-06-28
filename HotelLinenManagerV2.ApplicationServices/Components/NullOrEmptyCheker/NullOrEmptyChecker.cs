using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagerV2.ApplicationServices.Components.NullOrEmptyCheker
{
    public class NullOrEmptyChecker : INullOrEmptyChecker
    {
        public bool IsEmptyOrNull<T>(T parameter1, T parameter2, T parameter3)
        {
            if (string.IsNullOrEmpty(parameter1.ToString())
                || string.IsNullOrEmpty(parameter2.ToString())
                || string.IsNullOrEmpty(parameter3.ToString())) return true;
            return false;
        }
    }
}
