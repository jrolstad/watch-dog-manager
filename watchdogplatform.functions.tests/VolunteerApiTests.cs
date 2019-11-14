using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using watchdogplatform.core.Models;
using watchdogplatform.functions.tests.TestUtility;
using watchdogplatform.functions.tests.TestUtility.Extensions;
using Xunit;

namespace watchdogplatform.functions.tests
{
    public class VolunteerApiTests
    {
        [Fact]
        public async Task Run_GetRequest_ReturnsAllVolunteers()
        {
            // Given
            var root = TestCompositionRoot.Create();

            var api = root.Get<VolunteerApi>();

            // When
            var result = await api.Run(root.HttpRequest(), root.CoreLogger());

            // Then
            var volunteers = result.AssertIsOkResultWithValue<List<Volunteer>>();
            Assert.NotEmpty(volunteers);

        }
    }
}