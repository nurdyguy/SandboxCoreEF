using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SandboxCoreEF.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TempPassword { get; set; }
        //public IEnumerable<string> Roles { get; set; }
    }
}
