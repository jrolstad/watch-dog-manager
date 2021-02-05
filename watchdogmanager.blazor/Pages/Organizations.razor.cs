using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;
using watchdogmanager.blazor.Services;

namespace watchdogmanager.blazor.Pages
{
    public partial class Organizations
    {
        [Inject]
        public IApiService ApiService {get;set;}
        [Inject]
        public AppState AppState { get;set;}

        public List<Organization> Data { get; set; }
        public Organization SelectedItem { get; set; }

        private bool DialogIsOpen = false;

        protected override async Task OnInitializedAsync()
        {
            await RefreshData();
        }

        void OpenNewDialog()
        {
            SelectedItem = new Organization();
            ShowSelectedItem();
        }

        async Task SaveClick()
        {
            DialogIsOpen = false;

            ResetData();
            await ApiService.SaveOrganization(SelectedItem);
            await RefreshData();
        }
        async Task CancelClick()
        {
            DialogIsOpen = false;
        }


        async Task OnEdit(string id)
        {
            SelectedItem = Data.FirstOrDefault(o => o.Id == id);
            ShowSelectedItem();
        }

        async Task OnDelete(string id)
        {
            SelectedItem = Data.FirstOrDefault(o => o.Id == id);
            if (SelectedItem != null)
            {
                ResetData();
                await ApiService.DeleteOrganization(SelectedItem.Id);
                await RefreshData();
            }
        }

        void ShowSelectedItem()
        {
            if (SelectedItem != null)
            {
                DialogIsOpen = true;
                StateHasChanged();
            }
        }

        async Task RefreshData()
        {
            Data = await ApiService.GetOrganizations();
            StateHasChanged();
        }

        void ResetData()
        {
            Data = null;
            StateHasChanged();
        }
    }
}
