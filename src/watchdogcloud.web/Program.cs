using Microsoft.Identity.Web.Resource;
using watchdogcloud.web.Configuration;
using watchdogcloud.web.Endpoints;

var builder = WebApplication.CreateBuilder(args);

AuthenticationConfig.Register(builder.Services, builder.Configuration);
SwaggerConfig.Register(builder.Services);

var app = builder.Build();

SwaggerConfig.Configure(app);
RoutingConfig.Configure(app);
AuthenticationConfig.Configure(app);

TenantEndpointConfig.Configure(app);

app.Run();
