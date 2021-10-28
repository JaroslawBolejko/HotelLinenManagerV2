using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.PriceLists
{
    public interface IPriceListService
    {
        Task<IEnumerable<Models.PriceList>> GetAllLaundry();
        Task<Models.PriceList> GetLaundryById(int id);
        Task<int> CreateLaundry(Models.PriceList priceList);
        Task<int> UpdateLaundry(Models.PriceList priceList);
        Task<bool> Delete(int id);
    }
}
