using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Data.Repositories
{
    public class AssemblingRepository : BaseRepository<GolgiDbContext, AssemblingEntity, Guid>, IAssemblingRepository
    {
        public AssemblingRepository(GolgiDbContext context) : base(context)
        {
        }
    }
}
