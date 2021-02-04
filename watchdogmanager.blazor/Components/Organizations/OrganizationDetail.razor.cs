using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Components.Organizations
{
    public partial class OrganizationDetail
    {
        [Parameter]
        public Organization Data { get; set; }
    }
}
