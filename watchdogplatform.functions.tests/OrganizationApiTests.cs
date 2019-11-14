using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogplatform.core.Models;
using watchdogplatform.functions.tests.TestUtility;
using watchdogplatform.functions.tests.TestUtility.Extensions;
using Xunit;

namespace watchdogplatform.functions.tests
{
    public class OrganizationApiTests
    {
        [Fact]
        public async Task Run_GetRequest_ReturnsAllOrganization()
        {
            // Given
            var root = TestCompositionRoot.Create();
            root.WithOrganization("one-organization");

            var api = root.Get<OrganizationApi>();

            // When
            var result = await api.Run(root.GetRequest(), root.CoreLogger());

            // Then
            var responseData = result.AssertIsOkResultWithValue<List<Organization>>();
            Assert.NotEmpty(responseData);
        }

        [Fact]
        public async Task Run_PostRequest_SavesOrganization()
        {
            // Given
            var root = TestCompositionRoot.Create();

            var api = root.Get<OrganizationApi>();

            var request = new Organization()
            {
                Name = "the-name",
                AffiliatedWith = "someone"
            };

            // When
            var result = await api.Run(root.PostRequest(request), root.CoreLogger());

            // Then
            var volunteer = result.AssertIsOkResultWithValue<Organization>();
            Assert.NotNull(volunteer);

            var getResponse = await api.Run(root.GetRequest(), root.CoreLogger());
            var responseData = getResponse.AssertIsOkResultWithValue<List<Organization>>();
            Assert.Equal(1, responseData.Count(v=>v.Name == "the-name"));
        }
    }
}