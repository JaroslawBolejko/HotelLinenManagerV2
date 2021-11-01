using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.PriceListDetails
{
    public class PriceListDetailsService : IPriceListDetailsService
    {
        private readonly IHttpService httpService;

        public PriceListDetailsService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<int> CreateLaundry(PriceListDetail priceListDetails)
        {
            var result = await this.httpService.Post<PriceListDetail>("/priceListDetails", priceListDetails);
            return result.Id;
        }

        public async Task<bool> Delete(int id)
        {
            await this.httpService.Delete($"/priceListDetails/{id}");
            return true;
        }

        public async Task<IEnumerable<PriceListDetail>> GetAllLaundry()
        {
           return await this.httpService.Get<List<PriceListDetail>>("/priceListDetails");
        }

        public async Task<PriceListDetail> GetLaundryById(int id)
        {
            return await this.httpService.Get<PriceListDetail>($"/priceListDetails/{id}");
        }

        public async Task<int> UpdateLaundry(PriceListDetail priceListDetails)
        {
            var result = await this.httpService.Put<PriceListDetail>($"/priceListDetails/{priceListDetails.Id}", priceListDetails);
            return result.Id;
        }
    }
}
