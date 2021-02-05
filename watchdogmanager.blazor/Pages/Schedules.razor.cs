using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;
using watchdogmanager.blazor.Services;

namespace watchdogmanager.blazor.Pages
{
    public partial class Schedules
    {


        [Inject]
        public AppState AppState { get; set; }

        //public List<Instructor> Data { get; set; }

        void OpenNewDialog()
        {

        }
    }
}
