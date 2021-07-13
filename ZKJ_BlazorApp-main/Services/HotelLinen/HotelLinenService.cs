using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
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
            return  await this.httpService.Get<IEnumerable<HotelLinen>>("/Hotellinens");
        }
        public async Task<HotelLinen> GetById(int id)
        {
            return await this.httpService.Get<HotelLinen>($"/Hotellinens/{id}");
        }
        public async Task<HotelLinen> Create(HotelLinen hotelLinen)
        {
           return await this.httpService.Post<HotelLinen>("/Hotellinens", hotelLinen);

        }
        public async Task<HotelLinen> Update(HotelLinen hotelLinen)
        {
            return await this.httpService.Put<HotelLinen>("/Hotellinens", hotelLinen);
        }
      
        public async Task<int> Delete(int id)
        {
            await this.httpService.Delete($"/Hotellinens/{id}");
            return id;
        }
        

    }
}
