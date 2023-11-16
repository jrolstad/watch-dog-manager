using watchdogcloud.core.Models;
using watchdogcloud.core.Orchestrators;

namespace watchdogcloud.web.Endpoints
{
    public static class TenantEndpointConfig
    {
        public static string ResourceName = "tenant";

        public static void Configure(IEndpointRouteBuilder app )
        {
            ConfigureGetAll(app);
            ConfigureGet(app);
            ConfigurePost(app);
            ConfigurePut(app);
            ConfigureDelete(app);
        }

        private static void ConfigureGetAll(IEndpointRouteBuilder app)
        {
            app.MapGet($"/{ResourceName}", (HttpContext httpContext, TenantOrchestrator orchestrator) =>
            {
                return orchestrator.Get();
            })
            .WithName("GetTenants")
            .WithOpenApi()
            .RequireAuthorization();
        }

        private static void ConfigureGet(IEndpointRouteBuilder app)
        {
            app.MapGet($"/{ResourceName}/{{id}}", async (string id, HttpContext httpContext, TenantOrchestrator orchestrator) =>
            {
                return await orchestrator.Get(id);
            })
            .WithName("GetTenant")
            .WithOpenApi()
            .RequireAuthorization();
        }

        private static void ConfigurePost(IEndpointRouteBuilder app)
        {
            app.MapPost($"/{ResourceName}/", async (Tenant body, HttpContext httpContext, TenantOrchestrator orchestrator) =>
            {
                return await orchestrator.Create(body);
            })
            .WithName("CreateTenant")
            .WithOpenApi()
            .RequireAuthorization();
        }

        private static void ConfigurePut(IEndpointRouteBuilder app)
        {
            app.MapPut($"/{ResourceName}/{{id}}", async (string id, Tenant body, HttpContext httpContext, TenantOrchestrator orchestrator) =>
            {
                return await orchestrator.Update(body);
            })
            .WithName("UpdateTenant")
            .WithOpenApi()
            .RequireAuthorization();
        }

        private static void ConfigureDelete(IEndpointRouteBuilder app)
        {
            app.MapDelete($"/{ResourceName}/{{id}}", async (string id, HttpContext httpContext, TenantOrchestrator orchestrator) =>
            {
                await orchestrator.Delete(id);
            })
            .WithName("DeleteTenant")
            .WithOpenApi()
            .RequireAuthorization();
        }
    }
}
