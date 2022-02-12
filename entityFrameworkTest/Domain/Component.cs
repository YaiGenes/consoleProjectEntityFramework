using entityFrameworkTest.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Domain
{
    public class Component
    {
        public string ProteinType { get; set; }
        public bool Chaperonine { get; set; }
        public bool HSP80 { get; set; }
        public bool Ubiquitination { get; set; }
        public double EnergyIncrease { get; set; }
        public List<SubcomponentDTO> Subcomponents { get; set; }
        public int NumComponents { get; set; }
        public double Temp { get; set; }
        public double Ph { get; set; }

        public double GetYield()
        {
            return (1 / (EnergyIncrease + (Subcomponents.Sum(c => c.Energy))/NumComponents)) * 100; 
        }
    }
}
