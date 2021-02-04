using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace watchdogmanager.Managers
{
    public class AuthorizationManager
    {
        private readonly IConfiguration _configuration;

        public AuthorizationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CanManageOrganizations(IPrincipal user)
        {
            if (IsDevelopment()) return true;

            return user.Identity?.IsAuthenticated ?? false;
        }

        public bool CanManageVolunteers(IPrincipal user, string organizationId)
        {
            if (IsDevelopment()) return true;

            return user.Identity?.IsAuthenticated ?? false;
        }

        public bool CanManageInstructors(IPrincipal user, string organizationId)
        {
            if (IsDevelopment()) return true;

            return user.Identity?.IsAuthenticated ?? false;
        }

        private bool IsDevelopment()
        {
            return string.Equals("Development", EnvironmentName());
        }

        private string EnvironmentName()
        {
            return _configuration["ASPNETCORE_ENVIRONMENT"];
        }
    }
}
