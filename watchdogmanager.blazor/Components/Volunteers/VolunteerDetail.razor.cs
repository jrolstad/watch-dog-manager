using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Components.Volunteers
{
    public partial class VolunteerDetail
    {
        [Parameter]
        public Volunteer Data { get; set; }
    }
}
