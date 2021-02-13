using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Components.ScheduleTemplates
{
    public partial class ScheduleTemplateDetail
    {
        [Parameter]
        public ScheduleTemplate Data { get; set; }
    }
}
