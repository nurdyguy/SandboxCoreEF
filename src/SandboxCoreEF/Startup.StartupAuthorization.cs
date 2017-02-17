using Microsoft.AspNetCore.Authorization;

namespace SandboxCoreEF
{
    public static class StartupAuthorization
    {
        public static void AddSecurity(this AuthorizationOptions auth)
        {
			auth.AddPolicy("Owner", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("Owner");
            });

            auth.AddPolicy("Admin", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("Admin", "Owner");
            });

            auth.AddPolicy("User", policy =>
            {
                policy.RequireAuthenticatedUser();
                //policy.RequireClaim("User", "Admin", "Owner");
            });

            
        }
    }
}
