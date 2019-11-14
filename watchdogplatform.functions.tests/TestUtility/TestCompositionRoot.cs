using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using watchdogplatform.core.Repositories;
using watchdogplatform.functions.Application;
using watchdogplatform.functions.tests.TestUtility.Extensions;
using watchdogplatform.functions.tests.TestUtility.Fakes;

namespace watchdogplatform.functions.tests.TestUtility
{
    public class TestCompositionRoot
    {
        private readonly ServiceProvider _provider;

        public static TestCompositionRoot Create()
        {
            return new TestCompositionRoot(new ServiceCollection());
        }

        private TestCompositionRoot(IServiceCollection serviceCollection)
        {
            DependencyInjectionConfig.Configure(serviceCollection);
            RegisterFunctions(serviceCollection);
            RegisterFakes(serviceCollection);
            _provider = serviceCollection.BuildServiceProvider();
        }

        public TestContext Context => _provider.GetService<TestContext>();

        private void RegisterFunctions(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<HealthApi>();
            serviceCollection.AddTransient<UserApi>();
            serviceCollection.AddTransient<VolunteerApi>();
        }
        private void RegisterFakes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<TestContext>();
            serviceCollection.ReplaceTransient<IHttpContextAccessor, FakeHttpContextAccessor>();

            serviceCollection.ReplaceSingleton<ILogger<VolunteerRepository>, FakeLogger<VolunteerRepository>>();
        }

        public T Get<T>()
        {
            return _provider.GetService<T>();
        }

        public ILogger CoreLogger()
        {
            return new FakeLogger<object>(this.Context);
        }

        public HttpRequest GetRequest()
        {
            var request = new DefaultHttpRequest(new DefaultHttpContext()) {Method = "GET"};
            return request;
        }

        public HttpRequest PostRequest<T>(T body)
        {
            var request = new DefaultHttpRequest(new DefaultHttpContext()) {Method = "POST"};
            var bodyAsJson = JsonConvert.SerializeObject(body);
            request.Body = bodyAsJson.ToStream();

            return request;

        }
    }

    public class TestContext
    {
        public ClaimsPrincipal CurrentPrincipal;
        public List<LoggedMessage> LoggedMessages = new List<LoggedMessage>();
    }
}