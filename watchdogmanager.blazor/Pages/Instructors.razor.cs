using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;
using watchdogmanager.blazor.Services;

namespace watchdogmanager.blazor.Pages
{
    public partial class Instructors
    {

        [Inject]
        public IApiService ApiService { get; set; }

        [Inject]
        public AppState AppState { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<Instructor> Data { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AppState.Initialize();
            await RefreshData();
        }

        async Task OnEdit(string id)
        {
            var item = Data.FirstOrDefault(o => o.Id == id);
            ShowSelectedItem(item);
        }

        async Task OnDelete(string id)
        {
            var item = Data.FirstOrDefault(o => o.Id == id);
            if (item != null)
            {
                ResetData();
                await ApiService.Delete<Instructor>(item.Id, AppState.CurrentOrganization.Id);
                await RefreshData();
            }
        }

        void AddNew()
        {
            NavigationManager.NavigateTo($"/instructors/{AppState.CurrentOrganization.Id}");

        }

        void ShowSelectedItem(Instructor item)
        {
            if (item != null)
            {
                NavigationManager.NavigateTo($"/instructors/{AppState.CurrentOrganization.Id}/{item?.Id}");
            }
        }

        async Task RefreshData()
        {
            Data = await ApiService.Get<Instructor>(AppState.CurrentOrganization.Id);
            StateHasChanged();
        }

        void ResetData()
        {
            Data = null;
            StateHasChanged();
        }
    }
}
