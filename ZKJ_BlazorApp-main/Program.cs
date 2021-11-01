using BlazorApp.Helpers;
using BlazorApp.Services.Authentications;
using BlazorApp.Services.Companies;
using BlazorApp.Services.HotelLinens;
using BlazorApp.Services.HttpServices;
using BlazorApp.Services.LaundryServiceDetails;
using BlazorApp.Services.LaundryServices;
using BlazorApp.Services.LocalStorages;
using BlazorApp.Services.PriceListDetails;
using BlazorApp.Services.PriceLists;
using BlazorApp.Services.RelatedCompanies;
using BlazorApp.Services.Users;
using BlazorApp.Services.WarehauseDetails;
using BlazorApp.Services.Warehauses;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTE0MjU0QDMxMzkyZTMzMmUzMExkQngvUWUrcTkzbGYrWjh4KzUwQys2SW5QbisreGErbmxmcVl1SkZoU0U9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");
            builder.Services.AddSyncfusionBlazor();
            builder.Services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICompanyService, CompanyService>()
                .AddScoped<IPriceListService, PriceListService>()
                .AddScoped<IPriceListDetailsService, PriceListDetailsService>()
                .AddScoped<IRelatedCompaniesService, RelatedCompaniesService>()
                .AddScoped<IWarehauseService, WarehauseService>()
                .AddScoped<IHotelLinenService, HotelLinenService>()
                .AddScoped<IWarehauseDetailsService, WarehauseDetailsService>()
                .AddScoped<ILaundryServiceDetailsService, LaundryServiceDetailsService>()
                .AddScoped<ILaundryServiceService, LaundryServiceService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            // configure http client
            builder.Services.AddScoped(x =>
            {
                var apiUrl = new Uri(builder.Configuration["apiUrl"]);
                return new HttpClient() { BaseAddress = apiUrl };
            });

            var host = builder.Build();

            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.Initialize();

            await host.RunAsync();
        }
    }
}