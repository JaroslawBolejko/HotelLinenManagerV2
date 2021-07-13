using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    interface IWarehauseService
    {
        Task<IEnumerable<Warehause>> GetAll();
    }
}
