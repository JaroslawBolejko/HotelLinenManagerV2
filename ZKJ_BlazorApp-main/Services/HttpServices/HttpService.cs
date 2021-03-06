using BlazorApp.Models;
using BlazorApp.Services.LocalStorages;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp.Services.HttpServices
{
    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public HttpService(
            HttpClient httpClient,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await SendRequest<T>(request);
        }

        public Task<T> Post<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return SendRequest<T>(request);
        }

        public Task<T> Put<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return SendRequest<T>(request);
        }

        public Task Delete(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            return SendRequest<bool>(request);
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage request)
        {
            // add basic auth header if user is logged in and request is to the api url
            var user = await _localStorageService.GetItem<User>("user");
            var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            if (user != null && isApiUrl)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", user.AuthData);
            }

            using var response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("logout");
                return default;
            }
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                _navigationManager.NavigateTo("409Conflict", forceLoad: true);
                return default;
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _navigationManager.NavigateTo("404NotFound", forceLoad: true);
                return default;
            }
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                _navigationManager.NavigateTo("403Forbidden", forceLoad: true);
                return default;
            }
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                _navigationManager.NavigateTo("400BadRequest", forceLoad: true);
                return default;
            }

            if (!response.IsSuccessStatusCode )   
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var result = await response.Content.ReadFromJsonAsync<Reponse<T>>();
            return result.Data;
        }
    }
}