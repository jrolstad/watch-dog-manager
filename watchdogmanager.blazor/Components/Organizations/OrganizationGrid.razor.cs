using MatBlazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Components.Organizations
{
    public partial class OrganizationGrid
    {
        [Parameter]
        public List<Organization> Data { get; set; }

        void SortData(MatSortChangedEvent sort)
        {

            if(sort != null && sort.SortId != null)
            {
                if(sort.SortId == "name" && sort.Direction == MatSortDirection.Asc)
                {
                    Data = Data.OrderBy(o => o.Name).ToList();
                }
                if (sort.SortId == "name" && sort.Direction == MatSortDirection.Desc)
                {
                    Data = Data.OrderByDescending(o => o.Name).ToList();
                }

                if (sort.SortId == "id" && sort.Direction == MatSortDirection.Asc)
                {
                    Data = Data.OrderBy(o => o.Id).ToList();
                }
                if (sort.SortId == "id" && sort.Direction == MatSortDirection.Desc)
                {
                    Data = Data.OrderByDescending(o => o.Id).ToList();
                }
            }
        }
    }
}
