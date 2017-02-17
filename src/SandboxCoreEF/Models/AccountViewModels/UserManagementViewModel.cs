using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCoreEF.Models.AccountViewModels
{
    public class UserManagementViewModel
    {
        public List<UserViewModel> Owners { get; set; }
        public List<UserViewModel> Admins { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}
