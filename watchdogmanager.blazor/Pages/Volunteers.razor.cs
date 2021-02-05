using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;
using watchdogmanager.blazor.Services;

namespace watchdogmanager.blazor.Pages
{
    public partial class Volunteers
    {
        [Inject]
        public IApiService ApiService { get; set; }

        [Inject]
        public AppState AppState { get; set; }

        public List<Volunteer> Data { get; set; }

        void OpenNewDialog()
        {
            
        }

        async Task OnEdit(string id)
        {

        }

        async Task OnDelete(string id)
        {

        }
    }
}
