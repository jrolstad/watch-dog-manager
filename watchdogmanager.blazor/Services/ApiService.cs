using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Services
{
    public interface IApiService<T>
    {
        Task<List<T>> Get(string organizationId=null);
        Task Save(T toSave, string organizationId = null);
        Task Delete(string id, string organizationId = null);
    }

    public class ApiService<T>:IApiService<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _resourcePath;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _resourcePath = $"api/{typeof(T).Name.ToLower()}";
        }

        public async Task<List<T>> Get(string organizationId=null)
        {
            var client = _httpClientFactory.CreateClient("ApiAuthenticated");

            var data = await client.GetFromJsonAsync<List<T>>($"{GetBasePath(organizationId)}");

            return data;
        }

        public async Task Save(T toSave, string organizationId = null)
        {
            var client = _httpClientFactory.CreateClient("ApiAuthenticated");
            var objectWithIdentity = toSave as IIdentifiable;

            if (string.IsNullOrWhiteSpace(objectWithIdentity.Id))
            {
                var result = await client.PostAsJsonAsync($"{GetBasePath(organizationId)}", toSave);
                result.EnsureSuccessStatusCode();
            }
            else
            {
                var result = await client.PutAsJsonAsync($"{GetBasePath(organizationId)}/{objectWithIdentity.Id}", toSave);
                result.EnsureSuccessStatusCode();
            }
        }

        public async Task Delete(string id, string organizationId = null)
        {
            var client = _httpClientFactory.CreateClient("ApiAuthenticated");

            var result = await client.DeleteAsync($"{GetBasePath(organizationId)}/{id}");
            result.EnsureSuccessStatusCode();
        }

        private string GetBasePath(string organizationId)
        {
            if (string.IsNullOrWhiteSpace(organizationId)) return _resourcePath;

            return $"{_resourcePath}/{organizationId}";
        }

        
    }
}
