using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.PriceLists
{
    public interface IPriceListService
    {
        Task<IEnumerable<Models.PriceList>> GetAllPriceLists();
        Task<IEnumerable<Models.PriceList>> GetAllPriceLists(int companyId, int laundryId);
        Task<Models.PriceList> GetPriceListById(int id);
        Task<int> CreatePriceList(Models.PriceList priceList);
        Task<int> UpdatePriceList(Models.PriceList priceList);
        Task<bool> Delete(int id);
    }
}
