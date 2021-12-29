using BlazorApp.Helpers;
using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using BlazorApp.Services.LocalStorages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorApp.Services.Authentications
{
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public User User { get; private set; }
        public User UserData { get; private set; }

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>("user");
        }

        public async Task Login(string username, string password)
        {
            User = new User()
            {
                AuthData = $"{username}:{password}".EncodeBase64()

            };
            await _localStorageService.SetItem("user", User);
            UserData = await _httpService.Get<User>("/Users/me");
            await _localStorageService.SetItem("userData", UserData);

        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem("user");
            _navigationManager.NavigateTo("login");
        }
    }
}