using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        }

        public T Get<T>()
        {
            return _provider.GetService<T>();
        }

        public ILogger CoreLogger()
        {
            return new FakeLogger(this.Context);
        }

        public HttpRequest HttpRequest()
        {
            return new DefaultHttpRequest(new DefaultHttpContext());
        }
    }

    public class TestContext
    {
        public ClaimsPrincipal CurrentPrincipal { get; set; }
    }
}