using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.HotelLinens
{
    public class HotelLinenService : IHotelLinenService
    {
        private readonly IHttpService httpService;

        public HotelLinenService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<IEnumerable<HotelLinen>> GetAll()
        {
            return await this.httpService.Get<IEnumerable<HotelLinen>>("/HotelLinens");
        }
        public async Task<HotelLinen> GetById(int id)
        {
            return await this.httpService.Get<HotelLinen>($"/HotelLinens/{id}");
        }
        public async Task<HotelLinen> Create(HotelLinen hotelLinen)
        {
            return await this.httpService.Post<HotelLinen>("/HotelLinens", hotelLinen);

        }
        public async Task<HotelLinen> Update(HotelLinen hotelLinen)
        {
            return await this.httpService.Put<HotelLinen>($"/HotelLinens/{hotelLinen.Id}", hotelLinen);
        }

        public async Task<int> Delete(int id)
        {
            await this.httpService.Delete($"/HotelLinens/{id}");
            return id;
        }


    }
}
