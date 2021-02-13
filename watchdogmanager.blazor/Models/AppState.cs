using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using watchdogmanager.blazor.Services;

namespace watchdogmanager.blazor.Models
{
    public class AppState
    {
        private readonly IApiService _apiService;

        public AppState(IApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Organization> Organizations { get; set; }
        public Organization CurrentOrganization { get; set; }

        public Task InitializationTask { get; set; }

        public async Task Initialize()
        {
            if (CurrentOrganization==null)
            {
                Organizations = await _apiService.GetCollection<Organization>();
                CurrentOrganization = Organizations.First();
            }
            
        }
 
    }
}
