using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchdogmanager.blazor.Components
{
    public partial class EntityHeader
    {
        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Type { get; set; }
    }
}
