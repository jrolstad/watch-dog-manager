using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Shared
{
    public partial class MainLayout
    {
        protected void ModelDrawerHiddenChanged(bool hidden)
        {
            if (!hidden)
            {
                _navMenuOpened = false;
            }
        }

        bool _navMenuOpened = false;

        void MenuButtonClicked()
        {
            _navMenuOpened = !_navMenuOpened;
            this.StateHasChanged();
        }
    }
}
