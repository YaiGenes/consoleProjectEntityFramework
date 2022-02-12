using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Dto
{
        public class MolecularComponentsDTO
        {
            public string proteinType { get; set; }
            public List<SubcomponentDTO> subcomponents { get; set; }
            public double energyIncrease { get; set; }
            public int numComponents { get; set; }
            public double ph { get; set; }
            public double temp { get; set; }
            public CheckpointDTO checkpoint { get; set; }
    }
}
