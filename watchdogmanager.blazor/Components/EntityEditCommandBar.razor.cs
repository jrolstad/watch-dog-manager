using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchdogmanager.blazor.Components
{
    public partial class EntityEditCommandBar
    {
        [Parameter]
        public Func<Task> OnSave { get; set; }
        [Parameter]
        public Func<Task> OnCancel { get; set; }
    }
}
