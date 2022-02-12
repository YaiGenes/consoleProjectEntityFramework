using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Dto
{
    public class GolgiComplexDto
    {
        public int id { get; set; }
        public string order { get; set; }
        public List<MolecularComponentsDTO> detail { get; set; }
    }
}
