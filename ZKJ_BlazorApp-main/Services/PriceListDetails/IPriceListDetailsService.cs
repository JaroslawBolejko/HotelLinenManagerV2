using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.PriceListDetails
{
    public interface IPriceListDetailsService
    {
        Task<IEnumerable<Models.PriceListDetail>> GetAllPriceDetails();
        Task<IEnumerable<Models.PriceListDetail>> GetAllPriceDetails(int priceListId);
        Task<Models.PriceListDetail> GetPriceDetailById(int id);
        Task<int> CreatePriceDetail(Models.PriceListDetail priceListDetails);
        Task<int> UpdatePriceDetail(Models.PriceListDetail priceListDetails);
        Task<bool> Delete(int id);
    }
}
