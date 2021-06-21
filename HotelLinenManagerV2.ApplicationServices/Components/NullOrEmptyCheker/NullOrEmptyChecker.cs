using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagerV2.ApplicationServices.Components.NullOrEmptyCheker
{
    public class NullOrEmptyChecker : INullOrEmptyChecker
    {
        public bool IsEmptyOrNull(Company company)
        {
            
            return false;
        }
    }
}
