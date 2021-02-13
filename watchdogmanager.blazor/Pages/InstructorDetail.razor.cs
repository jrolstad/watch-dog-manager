using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Mappers;
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

        [Inject]
        public InstructorAvailabilityMapper Mapper { get; set; }

        Instructor Data { get; set; }

        public List<InstructorAvailability> Availability { get; set; }


        protected override async Task OnParametersSetAsync()
        {
            var scheduleTemplates = await ApiService.GetCollection<ScheduleTemplate>(OrganizationId);

            if (string.IsNullOrWhiteSpace(Id))
            {
                Data = new Instructor();
                Availability = Mapper.Map(Id, new List<InstructorAvailability>(),scheduleTemplates);
            }
            else
            {
                Data = await ApiService.GetItem<Instructor>(OrganizationId, Id);
                var existingData = await ApiService.GetCollection<InstructorAvailability>(OrganizationId, Id);
                Availability = Mapper.Map(Id, existingData, scheduleTemplates);
            }
           
        }

        async Task Save()
        {
            var saveInstructorTask = ApiService.Save(Data, AppState.CurrentOrganization.Id);
            var saveAvailabilityTasks = Availability.Select(a => ApiService.Save(a, AppState.CurrentOrganization.Id)).ToList();

            await Task.WhenAll(saveInstructorTask);
            await Task.WhenAll(saveAvailabilityTasks);

            NavigationManager.NavigateTo("/instructors");
        }
        async Task Cancel()
        {
            NavigationManager.NavigateTo("/instructors");
        }
    }
}
