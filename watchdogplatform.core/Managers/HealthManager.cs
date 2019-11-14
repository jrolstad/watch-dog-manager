using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using watchdogplatform.core.Models;

namespace watchdogplatform.core.Managers
{
    public class HealthManager
    {
        public ApplicationHealth Get(Assembly versionedAssembly)
        {
            var dependencyStatus = GetDependencyStatus();
            var overallHealth = !dependencyStatus.Any() || dependencyStatus.Values.All(v => v);

            return new ApplicationHealth
            {
                Version = GetApplicationVersion(versionedAssembly),
                CurrentDateTime = DateTime.Now,
                DependencyStatus = dependencyStatus,
                Status = overallHealth
            };
        }

        public string GetApplicationVersion(Assembly versionedAssembly)
        {
            var version = versionedAssembly?.GetName()?.Version;
            var versionString = version?.ToString();

            return versionString;
        }

        private Dictionary<string, bool> GetDependencyStatus()
        {
            return new Dictionary<string, bool>();
        }
    }
}