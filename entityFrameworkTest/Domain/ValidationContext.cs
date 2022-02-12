using entityFrameworkTest.Dto;
using System.Collections.Generic;


namespace entityFrameworkTest.Domain
{
    public class ValidationContext
    {
        public IEnumerable<MolecularComponentsDTO> SourceComponents { get; set; }
        public Component Component { get; set; }
    }
}
