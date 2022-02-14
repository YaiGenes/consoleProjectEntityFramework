using System.Collections.Generic;
using System.Linq;


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
            var addition = Components.Sum(comp => comp.GetYield())/Components.Count;
            return addition * 100;
        }
    }
}
