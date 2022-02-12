using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Domain
{
    public class ComponentContext
    {
        public double Ph { get; set; }
        public double Temp { get; set; }
        public Component Component { get; set; }

        public ComponentContext() { }
        public ComponentContext(Component component, double ph) 
        { 
            Component = component;
            Ph = ph;
        }
        public ComponentContext(Component component, double temp, double ph)
        {
            Component = component;
            Temp = temp;
            Ph = ph;
        }
    }
}
