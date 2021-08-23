using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.WarehauseDetails
{
    public class WarehauseDetailsService : IWarehauseDetailsService
    {
        private readonly IHttpService httpService;

        public WarehauseDetailsService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<int> CreateDetails(WarehauseDetail warehauseDetail)
        {
            var result = await this.httpService.Post<WarehauseDetail>("/warehauseDetails", warehauseDetail);
            return result.Id;
        }

        public async Task<IEnumerable<WarehauseDetail>> GetAllDetails()
        {
            return await this.httpService.Get<IEnumerable<WarehauseDetail>>("/warehauseDetails");
        }
        public async Task<IEnumerable<WarehauseDetail>> GetWarehauseLinen(int warehauseId)
        {
            return await this.httpService.Get<IEnumerable<WarehauseDetail>>($"/WarehauseDetails?WarehauseId={warehauseId}");
        }
        public async Task<IEnumerable<WarehauseDetail>> GetDetailsWithQuery(int warehauseId, int hotelLinenId)
        {
            return await this.httpService.Get<IEnumerable<WarehauseDetail>>($"/WarehauseDetails?WarehauseId={warehauseId}&HotelLinenId={hotelLinenId}");
        }
        public async Task<WarehauseDetail> GetWarehauseDetailById(int id)
        {
            return await this.httpService.Get<WarehauseDetail>($"/warehauseDetails/{id}");
        }

        public async Task<int> UpdateDetails(WarehauseDetail warehausedetail)
        {
            await this.httpService.Put<WarehauseDetail>($"/warehauseDetails/{warehausedetail.Id}", warehausedetail);
            return warehausedetail.Id;
        }
        public async Task<bool> Delete(int id)
        {
            await this.httpService.Delete($"/warehauseDetails/{id}");
            return true;
        }

    }
}
