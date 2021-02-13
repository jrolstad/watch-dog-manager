using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;
using watchdogmanager.blazor.Services;

namespace watchdogmanager.blazor.Pages
{
    public partial class InstructorDetail
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

        Instructor Data { get; set; }

        public List<InstructorAvailability> Availability { get; set; }

        public List<ScheduleTemplate> ScheduleTemplates { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                Data = new Instructor();
                Availability = new List<InstructorAvailability>();
            }
            else
            {
                Data = await ApiService.GetItem<Instructor>(OrganizationId, Id);
                Availability = await ApiService.GetCollection<InstructorAvailability>(OrganizationId, Id);
            }
            ScheduleTemplates = await ApiService.GetCollection<ScheduleTemplate>(OrganizationId);
        }

        async Task Save()
        {
            await ApiService.Save(Data, AppState.CurrentOrganization.Id);
            NavigationManager.NavigateTo("/instructors");
        }
        async Task Cancel()
        {
            NavigationManager.NavigateTo("/instructors");
        }
    }
}
