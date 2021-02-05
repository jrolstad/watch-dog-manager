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
        public IApiService<Volunteer> VolunteerApiService { get; set; }
        [Inject]
        public IApiService<Instructor> InstructorApiService { get; set; }

        [Inject]
        public AppState AppState { get; set; }

        public List<Volunteer> Data { get; set; }
        public List<Instructor> AvailableInstructors { get; set; }

        public Volunteer SelectedItem { get; set; }

        private bool DialogIsOpen = false;

        protected override async Task OnInitializedAsync()
        {
            if(!AppState.InitializationTask.IsCompleted)
            {
                await AppState.InitializationTask;
            }
            await RefreshData();
        }

        void OpenNewDialog()
        {
            SelectedItem = new Volunteer();
            ShowSelectedItem();
        }

        async Task SaveClick()
        {
            DialogIsOpen = false;

            ResetData();
            await VolunteerApiService.Save(SelectedItem, AppState.CurrentOrganization.Id);
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
                await VolunteerApiService.Delete(SelectedItem.Id, AppState.CurrentOrganization.Id);
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
            Data = await VolunteerApiService.Get(AppState.CurrentOrganization.Id);
            AvailableInstructors = await InstructorApiService.Get(AppState.CurrentOrganization.Id);
            StateHasChanged();
        }

        void ResetData()
        {
            Data = null;
            StateHasChanged();
        }
    }
}
