using System.Collections.Generic;
using System.Security.Claims;
using watchdogplatform.functions.tests.TestUtility.Fakes;

namespace watchdogplatform.functions.tests.TestUtility
{
    public class TestContext
    {
        public ClaimsPrincipal CurrentPrincipal;
        public List<LoggedMessage> LoggedMessages = new List<LoggedMessage>();
    }
}