namespace watchdogcloud.web.Configuration
{
    public static class RoutingConfig
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
        }
    }
}
