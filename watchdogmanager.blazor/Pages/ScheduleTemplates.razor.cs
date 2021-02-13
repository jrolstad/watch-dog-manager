using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;
using watchdogmanager.blazor.Services;

namespace watchdogmanager.blazor.Pages
{
    public partial class ScheduleTemplates
    {
        [Inject]
        public IApiService ApiService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AppState AppState { get; set; }

        public List<ScheduleTemplate> Data { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AppState.Initialize();
            await RefreshData();
        }

        async Task OnEdit(string id)
        {
            var item = Data.FirstOrDefault(o => o.Id == id);
            ShowDetail(item);
        }

        async Task OnDelete(string id)
        {
            var item = Data.FirstOrDefault(o => o.Id == id);
            if (item != null)
            {
                ResetData();
                await ApiService.Delete<ScheduleTemplate>(item.Id, AppState.CurrentOrganization.Id);
                await RefreshData();
            }
        }

        void AddNew()
        {
            NavigationManager.NavigateTo($"/scheduletemplates/{AppState.CurrentOrganization.Id}");

        }
        void ShowDetail(ScheduleTemplate item)
        {
            NavigationManager.NavigateTo($"/scheduletemplates/{AppState.CurrentOrganization.Id}/{item?.Id}");
        }

        async Task RefreshData()
        {
            Data = await ApiService.Get<ScheduleTemplate>(AppState.CurrentOrganization.Id);
            StateHasChanged();
        }

        void ResetData()
        {
            Data = null;
            StateHasChanged();
        }
    }
}
