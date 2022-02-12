using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Data.Repositories
{
    internal interface ISubComponentRepository : IRepository<SubcomponentEntity, Guid>
    {
    }
}
