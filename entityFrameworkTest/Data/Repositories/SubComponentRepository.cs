using System;

namespace entityFrameworkTest.Data.Repositories
{
    public class SubComponentRepository : BaseRepository<GolgiDbContext, SubcomponentEntity, Guid>, ISubComponentRepository
    {
        public SubComponentRepository(GolgiDbContext context) : base(context)
        {
        }
    }
}
