using System.Collections.Generic;
using System.Security.Claims;

namespace watchdogplatform.functions.tests.TestUtility.Extensions
{
    public static class UserExtensions
    {
        public static void WithUnAuthenticatedUser(this TestCompositionRoot root)
        {
            root.Context.CurrentPrincipal = null;
        }

        public static void WithAuthenticatedUser(this TestCompositionRoot root, string name)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,name)
            };
            var claimsIdentity = new ClaimsIdentity(claims,"some-authentication-mechanism");
            
            root.Context.CurrentPrincipal = new ClaimsPrincipal(claimsIdentity);
        }
    }
}