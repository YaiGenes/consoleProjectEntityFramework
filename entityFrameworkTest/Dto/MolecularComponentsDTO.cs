using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Dto
{
        public class MolecularComponentsDTO
        {
            public string ProteinType { get; set; }
            public List<SubcomponentDTO> Subcomponents { get; set; }
            public double EnergyIncrease { get; set; }
            public int NumComponents { get; set; }
            public double Ph { get; set; }
            public double Temp { get; set; }
            public CheckpointDTO Checkpoint { get; set; }
    }
}
