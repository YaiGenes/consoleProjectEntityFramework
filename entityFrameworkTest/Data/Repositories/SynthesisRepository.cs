using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Data
{
    public class SynthesisRepository : BaseRepository<GolgiDbContext, SynthesisEntity, Guid>, ISynthesisRepository
    {
        public SynthesisRepository(GolgiDbContext context) : base(context)
        {
        }
    }
}
