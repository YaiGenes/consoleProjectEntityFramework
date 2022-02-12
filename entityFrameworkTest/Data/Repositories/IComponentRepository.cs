using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Data.Repositories
{
    public interface IComponentRepository : IRepository<ComponentEntity, Guid>
    {
        IEnumerable<SubcomponentEntity> GetSubcomponents(Guid componentId);
    }
}
