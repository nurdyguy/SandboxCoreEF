using AutoMapper;
using SandboxCoreEF.Models;
using SandboxCoreEF.Models.AccountViewModels;

namespace SandboxCoreEF.Mappings
{
    public class AccountProfiles : Profile
    {
        public AccountProfiles()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id));
        }
    }
}
