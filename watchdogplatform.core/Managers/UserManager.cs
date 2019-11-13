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
            return new User
            {
                Name = _currentPrincipal?.Identity?.Name
            };
        }
    }
}