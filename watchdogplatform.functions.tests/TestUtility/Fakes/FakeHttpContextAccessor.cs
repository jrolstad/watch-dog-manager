using Microsoft.AspNetCore.Http;

namespace watchdogplatform.functions.tests.TestUtility.Fakes
{
    public class FakeHttpContextAccessor:IHttpContextAccessor
    {
        private readonly TestContext _context;

        public FakeHttpContextAccessor(TestContext context)
        {
            _context = context;

            this.HttpContext = new DefaultHttpContext {User = context.CurrentPrincipal};

        }
        public HttpContext HttpContext { get; set; }
    }
}