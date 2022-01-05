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
            ///Do poprawy dzia�a ale najpierw powinienem pobra� dane zeby sprawdzi� czy jest taki go�c i dopiero go zapisac w lokal

            User = new User()
            {
                AuthData = $"{username}:{password}".EncodeBase64()

            };
            await _localStorageService.SetItem("user", User);

            UserData = await _httpService.Get<User>("/Users/me");
            if (UserData != null)
            {
                await _localStorageService.SetItem("userData", UserData);
            }
            else
            {
                await _localStorageService.RemoveItem("user");

            }


        }

        public async Task Logout()
        {
            User = null;
            UserData = null;
            await _localStorageService.RemoveItem("user");
            await _localStorageService.RemoveItem("userData");
            _navigationManager.NavigateTo("login");
        }
    }
}