using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Data.Repositories
{
    public class SubcomponentRepository : BaseRepository<GolgiDbContext, SubcomponentEntity, Guid>, ISubComponentRepository
    {
        public SubcomponentRepository(GolgiDbContext context) : base(context)
        {
        }
    }
}
