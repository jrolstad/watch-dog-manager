using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using watchdogplatform.core.Models;
using watchdogplatform.functions.tests.TestUtility;
using watchdogplatform.functions.tests.TestUtility.Extensions;
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
            var healthResult = result.AssertIsOkResultWithValue<ApplicationHealth>();

            Assert.True(!string.IsNullOrWhiteSpace(healthResult.Version));
            Assert.InRange(healthResult.CurrentDateTime, DateTime.Today, DateTime.Today.AddDays(1));

            Assert.True(healthResult.Status);
        }
    }
}
