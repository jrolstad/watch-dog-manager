﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace watchdogplatform.functions.tests.TestUtility.Extensions
{
    public static class UserExtensions
    {
        public static void WithUnAuthenticatedUser(this TestCompositionRoot root)
        {
            root.Context.CurrentPrincipal = null;
        }

        public static void WithAuthenticatedUser(this TestCompositionRoot root, string name, Dictionary<string,string> additionalClaims=null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,name)
            };

            if (additionalClaims != null)
            {
                var additionalClaimsResolved = additionalClaims.Select(c => new Claim(c.Key, c.Value));
                claims.AddRange(additionalClaimsResolved);
            }

            var claimsIdentity = new ClaimsIdentity(claims,"some-authentication-mechanism");
            
            root.Context.CurrentPrincipal = new ClaimsPrincipal(claimsIdentity);
        }
    }
}