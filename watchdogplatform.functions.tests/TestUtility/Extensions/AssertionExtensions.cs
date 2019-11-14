using Microsoft.AspNetCore.Mvc;
using watchdogplatform.core.Models;
using Xunit;

namespace watchdogplatform.functions.tests.TestUtility.Extensions
{
    public static class AssertionExtensions
    {
        public static T AssertIsOkResultWithValue<T>(this IActionResult result)
        {
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var typedResult = (OkObjectResult)result;
            Assert.NotNull(typedResult.Value);
            Assert.IsType<T>(typedResult.Value);

            var objectValue = (T)typedResult.Value;
            return objectValue;
        }
    }
}