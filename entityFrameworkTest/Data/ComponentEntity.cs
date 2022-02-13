using System.Collections.Generic;
using System;

namespace entityFrameworkTest.Data
{
    public partial class ComponentEntity
    {
        public ComponentEntity()
        {
            Subcomponents = new HashSet<SubcomponentEntity>();
        }

        public Guid Id { get; set; }
        public string ProteinType { get; set; }
        public bool Chaperonine { get; set; }
        public bool HSP80 { get; set; }
        public bool Ubiquitination { get; set; }
        public double EnergyIncrease { get; set; }
        public int NumComponents { get; set; }
        public double Temp { get; set; }
        public double Ph { get; set; }
        public Guid SynthesisId { get; set; }
        public virtual AssemblingEntity Synthesis { get; set; }
        public virtual ICollection<SubcomponentEntity> Subcomponents { get; set; }
    }
}