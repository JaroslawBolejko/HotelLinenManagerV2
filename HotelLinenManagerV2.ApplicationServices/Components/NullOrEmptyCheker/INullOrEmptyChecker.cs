using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;

namespace HotelLinenManagerV2.ApplicationServices.Components.NullOrEmptyCheker
{
    interface INullOrEmptyChecker
    {
        public bool IsEmptyOrNull(Company company);
    }
}
