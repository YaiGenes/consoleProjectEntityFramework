using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Dto
{
    public class GolgiComplexDto
    {
        public int Id { get; set; }
        public string Order { get; set; }
        public List<MolecularComponentsDTO> Detail { get; set; }
    }
}
