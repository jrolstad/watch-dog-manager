using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Components.Instructors
{
    public partial class InstructorAvailabilityDetail
    {
        [Parameter]
        public List<InstructorAvailability> Availability { get; set; }


        public InstructorAvailability SelectedItem { get; set; }

        List<DayOfWeek> DaysOfTheWeek { get; set; }

        protected override void OnInitialized()
        {
            DaysOfTheWeek = new List<DayOfWeek> 
            { 
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
            };
        }
        protected override async Task OnParametersSetAsync()
        {
            SelectedItem = Availability?.FirstOrDefault();
        }

    }
}
