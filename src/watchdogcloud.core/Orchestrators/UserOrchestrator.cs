using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace watchdogcloud.core.Orchestrators
{
    public class UserOrchestrator
    {
        public IEnumerable<KeyValuePair<string, string>> GetUserClaims(ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
            {
                return new List<KeyValuePair<string, string>>();
            }

            return user.Claims?
                .Select(c => new KeyValuePair<string, string>(c.Type, c.Value));
        }
    }
}
