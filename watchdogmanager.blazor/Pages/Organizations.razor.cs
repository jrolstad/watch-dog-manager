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

        public List<Organization> Data { get; set; }
        public Organization SelectedOrganization { get; set; }

        private bool DialogIsOpen = false;

        protected override async Task OnInitializedAsync()
        {
            await RefreshData();
        }

        void OpenNewDialog()
        {
            SelectedOrganization = new Organization();
            DialogIsOpen = true;
        }

        async Task SaveClick()
        {
            DialogIsOpen = false;

            Data = null;
            await ApiService.SaveOrganization(SelectedOrganization);
            await RefreshData();
        }
        async Task CancelClick()
        {

            DialogIsOpen = false;
        }

        async Task RefreshData()
        {
            Data = await ApiService.GetOrganizations();
        }
    }
}
