using System;

namespace entityFrameworkTest.Data
{
        public partial class SubcomponentEntity
        {
            public Guid Id { get; set; }
            public string Type { get; set; }
            public decimal Energy { get; set; }
            public Guid ComponentId { get; set; }
            public virtual ComponentEntity Component { get; set; }
        }
}