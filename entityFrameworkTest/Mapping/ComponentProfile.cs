using AutoMapper;
using entityFrameworkTest.Data;
using entityFrameworkTest.Domain;

namespace entityFrameworkTest.Mapping
{
    public class ComponentProfile : Profile
    {
        public ComponentProfile()
        {
            CreateMap<Component, ComponentEntity>();
        }
    }
}
