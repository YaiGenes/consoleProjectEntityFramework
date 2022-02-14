using AutoMapper;
using entityFrameworkTest.Data;
using entityFrameworkTest.Domain;
using System;

namespace entityFrameworkTest.Mapping
{
    public class AssemblingProfile : Profile
    {
        public AssemblingProfile()
        {
            CreateMap<Assembling, AssemblingEntity>()
                  .ForMember(c => c.Id, opt => Guid.NewGuid());
        }
    }
}
