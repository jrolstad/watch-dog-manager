using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchdogmanager.blazor.Configuration
{
    public class AuthenticationConfig
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorizationCore();

            services.AddMsalAuthentication(options =>
            {
                configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
                options.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/User.Read");

                options.ProviderOptions.LoginMode = "redirect";
            });
        }
    }
}
