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


        protected override async Task OnParametersSetAsync()
        {
            var scheduleTemplates = await ApiService.GetCollection<ScheduleTemplate>(OrganizationId);

            if (string.IsNullOrWhiteSpace(Id))
            {
                Data = new Instructor();
                Availability = GetAvailability(new List<InstructorAvailability>(),scheduleTemplates);
            }
            else
            {
                Data = await ApiService.GetItem<Instructor>(OrganizationId, Id);
                var existingData = await ApiService.GetCollection<InstructorAvailability>(OrganizationId, Id);
                Availability = GetAvailability(existingData, scheduleTemplates);
            }
           
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

        List<InstructorAvailability> GetAvailability(List<InstructorAvailability> existing, List<ScheduleTemplate> scheduleTemplates)
        {
            var result = new List<InstructorAvailability>(existing);

            foreach(var item in scheduleTemplates)
            {
                if(!result.Any(t=>t.ScheduleTemplateId == item.Id))
                {
                    result.Add(new InstructorAvailability
                    {
                        InstructorId = this.Id,
                        ScheduleTemplateId = item.Id,
                        Name = item.Name,
                        Availability = new List<InstructorSessionAvailability>()
                    });
                }

                var matchingTemplate = result.First(t => t.ScheduleTemplateId == item.Id);
                
                foreach(var session in item.Sessions.Where(s=>s.IsInstructorLed))
                {
                    if(!matchingTemplate.Availability.Any(t=>t.ScheduleTemplateSessionId == session.Id))
                    {
                        matchingTemplate.Availability.Add(new InstructorSessionAvailability 
                        { 
                            ScheduleTemplateSessionId = session.Id,
                            Start = session.Start,
                            IsAvailable = false,
                            DayOfWeek = ""
                        });
                    }
                }
            }

            return result;
        }
    }
}
