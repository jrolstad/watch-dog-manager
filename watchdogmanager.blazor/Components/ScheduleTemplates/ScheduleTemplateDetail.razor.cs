using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Components.Organizations;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Components.ScheduleTemplates
{
    public partial class ScheduleTemplateDetail
    {
        [Parameter]
        public ScheduleTemplate Data { get; set; }

        GenericCommand<ScheduleTemplateSession> DeleteSessionCommand { get; set; }

        protected override void OnInitialized()
        {
            DeleteSessionCommand = new GenericCommand<ScheduleTemplateSession>(DeleteSession);
        }

        protected override void OnParametersSet()
        {
            if (Data != null)
            {
                Data.Sessions = Data.Sessions ?? new List<ScheduleTemplateSession>();
            }

        }

        private void AddSession()
        {
            if (Data?.Sessions == null) Data.Sessions = new List<ScheduleTemplateSession>();
            Data.Sessions.Add(new ScheduleTemplateSession { IsInstructorLed = true });
        }

        private async Task DeleteSession(ScheduleTemplateSession session)
        {
            Data.Sessions.Remove(session);
            StateHasChanged();
        }
    }
}
