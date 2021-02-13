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

        protected override async Task OnParametersSetAsync()
        {
            SelectedItem = Availability?.FirstOrDefault();
        }

        List<string> GetDaysOfTheWeek(InstructorAvailability item)
        {
            if (item?.Availability == null) return new List<string>();

            return item.Availability
                .SelectMany(a => a.IsAvailable.Keys)
                .Distinct()
                .ToList();
        }

    }
}
