using AutoMapper;
using entityFrameworkTest.Data;
using entityFrameworkTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
