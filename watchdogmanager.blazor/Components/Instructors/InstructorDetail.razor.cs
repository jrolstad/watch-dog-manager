using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Components.Instructors
{
    public partial class InstructorDetail
    {
        [Parameter]
        public Instructor Data { get; set; }
    }
}
