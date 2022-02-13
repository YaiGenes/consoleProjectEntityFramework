﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Data.Repositories
{
    public class SubComponentRepository : BaseRepository<GolgiDbContext, SubcomponentEntity, Guid>, ISubComponentRepository
    {
        public SubComponentRepository(GolgiDbContext context) : base(context)
        {
        }
    }
}
