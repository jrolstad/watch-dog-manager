using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Services
{
    public interface IApiService
    {
        Task<List<Organization>> GetOrganizations();
        Task SaveOrganization(Organization toSave);
    }

    public class ApiService:IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Organization>> GetOrganizations()
        {
            var client = _httpClientFactory.CreateClient("Api");

            var data = await client.GetFromJsonAsync<List<Organization>>($"organization");

            return data;
        }

        public async Task SaveOrganization(Organization toSave)
        {
            var client = _httpClientFactory.CreateClient("Api");

            if (string.IsNullOrWhiteSpace(toSave.Id))
            {
                var result = await client.PostAsJsonAsync("organization", toSave);
                result.EnsureSuccessStatusCode();
            }
            else
            {
                var result = await client.PutAsJsonAsync($"organization/{toSave.Id}", toSave);
                result.EnsureSuccessStatusCode();
            }
        }
    }
}
