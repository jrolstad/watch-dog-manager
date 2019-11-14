using System.Security.Claims;
using System.Threading.Tasks;
using watchdogplatform.core.Models;

namespace watchdogplatform.core.Managers
{
    public class UserManager
    {
        private readonly ClaimsPrincipal _currentPrincipal;

        public UserManager(ClaimsPrincipal currentPrincipal)
        {
            _currentPrincipal = currentPrincipal;
        }

        public async Task<User> GetCurrent()
        {
            var user = Map(_currentPrincipal);
            return user;
        }

        private User Map(ClaimsPrincipal principal)
        {
            var user = new User
            {
                Name = principal?.Identity.Name
            };

            return user;
        }
    }
}