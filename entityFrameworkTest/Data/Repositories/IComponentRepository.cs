using System;
using System.Collections.Generic;

namespace entityFrameworkTest.Data.Repositories
{
    public interface IComponentRepository : IRepository<ComponentEntity, Guid>
    {
        IEnumerable<SubcomponentEntity> GetSubcomponents(Guid componentId);
    }
}
