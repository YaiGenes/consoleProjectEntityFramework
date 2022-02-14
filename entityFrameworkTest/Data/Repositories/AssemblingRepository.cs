using System;

namespace entityFrameworkTest.Data.Repositories
{
    public class AssemblingRepository : BaseRepository<GolgiDbContext, AssemblingEntity, Guid>, IAssemblingRepository
    {
        public AssemblingRepository(GolgiDbContext context) : base(context)
        {
        }
    }
}
