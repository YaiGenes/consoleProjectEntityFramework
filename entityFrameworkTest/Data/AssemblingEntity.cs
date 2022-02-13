using System.Collections.Generic;
using System;

namespace entityFrameworkTest.Data
{
    public class AssemblingEntity
    {
        public AssemblingEntity()
        {
            Components = new HashSet<ComponentEntity>();
        }

        public Guid Id { get; set; }
        public string Order { get; set; }

        public virtual ICollection<ComponentEntity> Components { get; set; }
    }
}