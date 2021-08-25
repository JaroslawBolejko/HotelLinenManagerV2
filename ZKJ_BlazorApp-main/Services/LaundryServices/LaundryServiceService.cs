using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.LaundryServices
{
    public class LaundryServiceService : ILaundryServiceService
    {
        private readonly IHttpService httpService;

        public LaundryServiceService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<int> CreateLaundry(LaundryService laundry)
        {
            var result = await this.httpService.Post<LaundryService>("/laundryServices", laundry);
            return result.Id;
        }

        public async Task<bool> Delete(int id)
        {
            await this.httpService.Delete($"/laundryServices/{id}");
            return true;
        }

        public async Task<IEnumerable<LaundryService>> GetAllLaundry()
        {
            return await this.httpService.Get<IEnumerable<LaundryService>>("/laundryServices");
        }
        public async Task<IEnumerable<LaundryService>> GetServiceByNumber(int number)
        {
            return await this.httpService.Get<IEnumerable<LaundryService>>($"/laundryServices?Number={number}");
        }
        public async Task<IEnumerable<LaundryService>> GetAllLaundryPageing(int pageNumber, int pageSize)
        {
            return await this.httpService.Get<IEnumerable<LaundryService>>($"/laundryServices?PageNumber={pageNumber}&PageSize={pageSize}");
        }
        public async Task<LaundryService> GetLaundryById(int id)
        {
            return await this.httpService.Get<LaundryService>($"/laundryServices/{id}");
        }

        public async Task<int> UpdateLaundry(LaundryService laundry)
        {
            await this.httpService.Put<LaundryService>($"/laundryServices/{laundry.Id}", laundry);
            return laundry.Id;
        }
    }
}
