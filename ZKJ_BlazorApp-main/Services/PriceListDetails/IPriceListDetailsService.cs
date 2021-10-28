using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.PriceListDetails
{
    public interface IPriceListDetailsService
    {
        Task<IEnumerable<Models.PriceListDetail>> GetAllLaundry();
        Task<Models.PriceListDetail> GetLaundryById(int id);
        Task<int> CreateLaundry(Models.PriceListDetail priceListDetails);
        Task<int> UpdateLaundry(Models.PriceListDetail priceListDetails);
        Task<bool> Delete(int id);
    }
}
