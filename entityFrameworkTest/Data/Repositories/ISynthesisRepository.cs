using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Data.Repositories
{
    internal interface ISynthesisRepository : IRepository<SynthesisEntity, Guid>
    {
    }
}
