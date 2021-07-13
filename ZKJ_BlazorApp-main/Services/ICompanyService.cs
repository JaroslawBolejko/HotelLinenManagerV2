using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Models.Company>> GetAll();
    }
}

