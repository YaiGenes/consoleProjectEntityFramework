using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Domain
{
    public class Assembling
    {
        public string Order { get; set; }
        public List<Component> Components { get; set; }
        public Assembling(IEnumerable<Component> components)
        {
            Components = new List<Component>();
            Components.AddRange(components);
        }
        public double GetMeanYield()
        {
            return Components.Sum(comp => comp.GetYield() * 1/comp.NumComponents) * 100;
        }
    }
}
