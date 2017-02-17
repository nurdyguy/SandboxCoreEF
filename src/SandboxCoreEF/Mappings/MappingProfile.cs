using AutoMapper;

namespace SandboxCoreEF.Mappings
{
    public class MappingProfile<TSource, TDestination> : Profile
    {
        public MappingProfile()
        {
            CreateMap<TSource, TDestination>().ReverseMap();
        }
    }
}
