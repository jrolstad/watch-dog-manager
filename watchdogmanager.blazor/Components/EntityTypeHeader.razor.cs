using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchdogmanager.blazor.Components
{
    public partial class EntityTypeHeader
    {
        [Parameter]
        public string Type { get; set; }

        [Parameter]
        public Action OnAdd { get; set; }

        [Parameter]
        public string AddCommandText { get; set; }
    }
}
