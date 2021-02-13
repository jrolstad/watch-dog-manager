using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Components.Organizations;

namespace watchdogmanager.blazor.Components
{
    public partial class EntityActionCommandBar
    {
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public GenericCommand<string> EditCommand { get; set; }
        [Parameter]
        public GenericCommand<string> DeleteCommand { get; set; }
    }
}
