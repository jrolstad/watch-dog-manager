using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;
using watchdogmanager.blazor.Services;

namespace watchdogmanager.blazor.Pages
{
    public partial class ScheduleTemplateDetail
    {
        [Parameter]
        public string OrganizationId { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IApiService ApiService { get; set; }

        [Inject]
        public AppState AppState { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        ScheduleTemplate Data { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                Data = new ScheduleTemplate { Name = "New Schedule",Sessions = new List<ScheduleTemplateSession>() };
            }
            else
            {
                Data = await ApiService.GetItem<ScheduleTemplate>(OrganizationId, Id);

            }
        }

        async Task Save()
        {
            await ApiService.Save(Data, AppState.CurrentOrganization.Id);
            NavigationManager.NavigateTo("/scheduletemplates");
        }
        async Task Cancel()
        {
            NavigationManager.NavigateTo("/scheduletemplates");
        }
    }
}
