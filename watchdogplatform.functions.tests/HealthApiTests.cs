using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using watchdogplatform.core.Models;
using watchdogplatform.functions.tests.TestUtility;
using Xunit;

namespace watchdogplatform.functions.tests
{
    public class HealthApiTests
    {
        [Fact]
        public async Task Run_NoInputs_ReturnsApplicationData()
        {
            // Given
            var root = TestCompositionRoot.Create();

            var api = root.Get<HealthApi>();

            // When
            var result = await api.Run(root.HttpRequest(), root.CoreLogger());

            // Then
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var typedResult = (OkObjectResult) result;
            Assert.NotNull(typedResult.Value);
            Assert.IsType<ApplicationHealth>(typedResult.Value);

            var healthResult = (ApplicationHealth) typedResult.Value;

            Assert.True(!string.IsNullOrWhiteSpace(healthResult.Version));
            Assert.InRange(healthResult.CurrentDateTime, DateTime.Today, DateTime.Today.AddDays(1));

            Assert.True(healthResult.Status);
        }
    }
}
