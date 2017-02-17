using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCoreEF.Models.AccountViewModels
{
    public class UpdateUserRolesViewModel
    {
        public List<int> NewOwners { get; set; }
        public List<int> NewAdmins { get; set; }
        public List<int> NewUsers { get; set; }
    }
}
