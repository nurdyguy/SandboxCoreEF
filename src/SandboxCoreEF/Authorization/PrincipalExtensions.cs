using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SandboxCoreEF.Authorization
{
    public static class PrincipalExtensions
    {
        public static bool IsOwner(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("Owner");
        }

        public static bool IsAdmin(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("Admin") || principal.IsInRole("Owner");
        }

        public static bool IsUser(this ClaimsPrincipal principal)
        {
            return principal.Identity.IsAuthenticated;
        }
    }
}
