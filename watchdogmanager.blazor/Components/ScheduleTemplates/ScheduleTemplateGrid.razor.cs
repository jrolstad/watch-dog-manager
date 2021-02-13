﻿using MatBlazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Components.Organizations;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Components.ScheduleTemplates
{
    public partial class ScheduleTemplateGrid
    {
        [Parameter]
        public List<ScheduleTemplate> Data { get; set; }

        [Parameter]
        public Func<string, Task> OnEdit { get; set; }

        [Parameter]
        public Func<string, Task> OnDelete { get; set; }

        GenericCommand<string> EditCommand { get; set; }
        GenericCommand<string> DeleteCommand { get; set; }

        protected override void OnParametersSet()
        {
            EditCommand = new GenericCommand<string>(OnEdit);
            DeleteCommand = new GenericCommand<string>(OnDelete);
        }

        void SortData(MatSortChangedEvent sort)
        {

            if (sort != null && sort.SortId != null)
            {
                if (sort.SortId == "name" && sort.Direction == MatSortDirection.Asc)
                {
                    Data = Data.OrderBy(o => o.Name).ToList();
                }
                if (sort.SortId == "name" && sort.Direction == MatSortDirection.Desc)
                {
                    Data = Data.OrderByDescending(o => o.Name).ToList();
                }
            }
        }
    }
}
