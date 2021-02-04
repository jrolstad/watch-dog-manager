using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Pages
{
    public partial class Organizations
    {
        public List<Organization> Data { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Data = new List<Organization> 
            { 
                new Organization{Id = Guid.NewGuid().ToString(),Name = "Brier Elementary"},
                new Organization{Id = Guid.NewGuid().ToString(),Name = "Mountlake Terrace High School"},
            };
        }
    }
}
