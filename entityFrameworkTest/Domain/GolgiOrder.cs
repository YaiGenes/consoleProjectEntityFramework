using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Domain
{
    public class GolgiOrder
    {
        public string Order { get; set; }
        public List<Component> Detail { get; set; }
    }
}
