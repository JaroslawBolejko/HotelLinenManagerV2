using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.PriceLists
{
    public class PriceListService : IPriceListService
    {
        private readonly IHttpService httpService;

        public PriceListService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<int> CreatePriceList(PriceList priceList)
        {
            var result = await this.httpService.Post<PriceList>("/priceLists", priceList);
            return result.Id;
        }

        public async Task<bool> Delete(int id)
        {
            await this.httpService.Delete($"/priceLists/{id}");
            return true;
        }

        public async Task<IEnumerable<PriceList>> GetAllPriceLists()
        {
            return await this.httpService.Get<IEnumerable<PriceList>>("/priceLists");
        }

        public async Task<IEnumerable<PriceList>> GetAllPriceLists(int companyId, int laundryId)
        {
            return await this.httpService.Get<IEnumerable<PriceList>>($"/priceLists?CompanyId={companyId}&LaundryId={laundryId}");
        }

        public async Task<PriceList> GetPriceListById(int id)
        {
            return await this.httpService.Get<PriceList>($"/priceLists/{id}");
        }

        public async Task<int> UpdatePriceList(PriceList priceList)
        {
            var result = await this.httpService.Put<PriceList>($"/priceLists/{priceList.Id}", priceList);
            return result.Id;
        }
    }
}
