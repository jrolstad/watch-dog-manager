using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var result = await api.Run(root.GetRequest(), root.CoreLogger());

            // Then
            var volunteers = result.AssertIsOkResultWithValue<List<Volunteer>>();
            Assert.NotEmpty(volunteers);
        }

        [Fact]
        public async Task Run_PostRequest_SavesVolunteer()
        {
            // Given
            var root = TestCompositionRoot.Create();

            var api = root.Get<VolunteerApi>();

            var request = new Volunteer
            {
                Name = "my-name",
                Email = "me@mail.com"
            };

            // When
            var result = await api.Run(root.PostRequest(request), root.CoreLogger());

            // Then
            var volunteer = result.AssertIsOkResultWithValue<Volunteer>();
            Assert.NotNull(volunteer);

            var allVolunteersResponse = await api.Run(root.GetRequest(), root.CoreLogger());
            var volunteers = allVolunteersResponse.AssertIsOkResultWithValue<List<Volunteer>>();
            Assert.Equal(1, volunteers.Count(v=>v.Name == "my-name"));
        }
    }
}