using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Data.Repositories
{
    public class ComponentRepository : BaseRepository<GolgiDbContext, ComponentEntity, Guid>, IComponentRepository
    {
        public ComponentRepository(GolgiDbContext context) : base(context)
        {
        }

        public IEnumerable<SubcomponentEntity> GetSubcomponents(Guid componentId)
        {
            var result = from com in Context.Components
                         join sub in Context.Subcomponents on com.Id equals sub.ComponentId
                         where com.Id == componentId
                         select sub;

            return result.ToList();
        }
    }
}
