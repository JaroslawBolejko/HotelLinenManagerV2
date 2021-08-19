using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.LaundryServiceDetails
{
    public class LaundryServiceDetailsService : ILaundryServiceDetailsService
    {
        private readonly IHttpService httpService;

        public LaundryServiceDetailsService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<int> CreateLaundryDetails(LaundryServiceDetail laundryDetail)
        {
            var result = await this.httpService.Post<LaundryServiceDetail>("/laundryServiceDetails", laundryDetail);
            return result.Id;
        }

        public async Task<int> Delete(int id)
        {
            await this.httpService.Delete($"/laundryServiceDetails/{id}");
            return id;
        }

        public async Task<IEnumerable<LaundryServiceDetail>> GetAllLaundryDetails()
        {
            return await this.httpService.Get<IEnumerable<LaundryServiceDetail>>($"/laundryServiceDetails");
        }
        public async Task<IEnumerable<LaundryServiceDetail>> GetLaundryServiceDetails(int laundryServiceId)
        {
            return await this.httpService.Get<IEnumerable<LaundryServiceDetail>>($"/laundryServiceDetails?LaundryServiceId={laundryServiceId}");
        }
        public async Task<LaundryServiceDetail> GetLaundryDetailById(int id)
        {
            return await this.httpService.Get<LaundryServiceDetail>($"/laundryServiceDetails/{id}");
        }

        public async Task<int> UpdateLaundryDetails(LaundryServiceDetail laundryDetail)
        {
            await this.httpService.Put<LaundryServiceDetail>($"/laundryServiceDetails/{laundryDetail.Id}", laundryDetail);
            return laundryDetail.Id;
        }
    }
}
