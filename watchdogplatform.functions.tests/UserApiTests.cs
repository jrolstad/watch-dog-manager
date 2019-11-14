using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using watchdogplatform.core.Models;
using watchdogplatform.functions.tests.TestUtility;
using watchdogplatform.functions.tests.TestUtility.Extensions;
using Xunit;

namespace watchdogplatform.functions.tests
{
    public class UserApiTests
    {
        [Fact]
        public async Task Run_UnAuthenticatedUser_ReturnsNoUserData()
        {
            // Given
            var root = TestCompositionRoot.Create();
            root.WithUnAuthenticatedUser();

            var api = root.Get<UserApi>();

            // When
            var result = await api.Run(root.HttpRequest(), root.CoreLogger());

            // Then
            var userResult = result.AssertIsOkResultWithValue<User>();

            Assert.Empty(userResult.Claims);
            Assert.Null(userResult.Name);
            Assert.False(userResult.IsAuthenticated);
        }

        [Fact]
        public async Task Run_AuthenticatedUser_ReturnsUserData()
        {
            // Given
            var root = TestCompositionRoot.Create();
            root.WithAuthenticatedUser("the-user");

            var api = root.Get<UserApi>();

            // When
            var result = await api.Run(root.HttpRequest(), root.CoreLogger());

            // Then
            var userResult = result.AssertIsOkResultWithValue<User>();

            Assert.Equal("the-user",userResult.Name);
            Assert.NotEmpty(userResult.Claims);
            Assert.True(userResult.IsAuthenticated);
        }

        
    }
}