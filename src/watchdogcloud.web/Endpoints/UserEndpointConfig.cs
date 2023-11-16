using Microsoft.Azure.Cosmos;
using System.Security.Claims;
using watchdogcloud.core.Orchestrators;

namespace watchdogcloud.web.Endpoints
{
    public class UserEndpointConfig
    {
        public static void Configure(IEndpointRouteBuilder app)
        {
            app.MapGet($"/user/claims", (HttpContext httpContext, ClaimsPrincipal user, UserOrchestrator orchestrator) =>
            {
                return orchestrator.GetUserClaims(user);
            })
            .WithName("GetUserClaims")
            .WithOpenApi()
            .RequireAuthorization();
        }
    }
}
