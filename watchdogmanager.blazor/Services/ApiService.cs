using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Services
{
    public interface IApiService
    {
        Task<List<T>> Get<T>(string organizationId=null);
        Task<T> Get<T>(string organizationId, string id);
        Task Save<T>(T toSave, string organizationId = null);
        Task Delete<T>(string id, string organizationId = null);
    }

    public class ApiService:IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<T>> Get<T>(string organizationId=null)
        {
            var client = _httpClientFactory.CreateClient("ApiAuthenticated");

            var data = await client.GetFromJsonAsync<List<T>>($"{GetBasePath<T>(organizationId)}");

            return data;
        }

        public async Task<T> Get<T>(string organizationId, string id)
        {
            var client = _httpClientFactory.CreateClient("ApiAuthenticated");

            var data = await client.GetFromJsonAsync<T>($"{GetBasePath<T>(organizationId)}/{id}");

            return data;
        }

        public async Task Save<T>(T toSave, string organizationId = null)
        {
            var client = _httpClientFactory.CreateClient("ApiAuthenticated");
            var objectWithIdentity = toSave as IIdentifiable;

            if (string.IsNullOrWhiteSpace(objectWithIdentity.Id))
            {
                var result = await client.PostAsJsonAsync($"{GetBasePath<T>(organizationId)}", toSave);
                result.EnsureSuccessStatusCode();
            }
            else
            {
                var result = await client.PutAsJsonAsync($"{GetBasePath<T>(organizationId)}/{objectWithIdentity.Id}", toSave);
                result.EnsureSuccessStatusCode();
            }
        }

        public async Task Delete<T>(string id, string organizationId = null)
        {
            var client = _httpClientFactory.CreateClient("ApiAuthenticated");

            var result = await client.DeleteAsync($"{GetBasePath<T>(organizationId)}/{id}");
            result.EnsureSuccessStatusCode();
        }

        private string GetBasePath<T>(string organizationId)
        {
            var resourcePath = $"api/{typeof(T).Name.ToLower()}";
            if (string.IsNullOrWhiteSpace(organizationId)) return resourcePath;

            return $"{resourcePath}/{organizationId}";
        }

        
    }
}
