using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IHttpService httpService;

        public CompanyService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<IEnumerable<Models.Company>> GetAll()
        {
            return await this.httpService.Get<IEnumerable<Models.Company>>("/Companies");
        }
    }
}
