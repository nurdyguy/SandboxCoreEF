using AutoMapper;
using SandboxCoreEF.Models;
using SandboxCoreEF.Models.AccountViewModels;


namespace SandboxCoreEF.Mappings
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AccountProfiles>();
                cfg.AddProfile<MappingProfile<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<int>, RoleViewModel>>();
            });
        }
    }
}
