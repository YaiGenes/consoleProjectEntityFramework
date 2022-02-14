using System;
using System.Collections.Generic;

namespace entityFrameworkTest.Dto
{
    public class GolgiComplexDto
    {
        public int Id { get; set; }
        public string Order { get; set; }
        public List<MolecularComponentsDTO> Detail { get; set; }

        public static explicit operator GolgiComplexDto(DataDTO v)
        {
            throw new NotImplementedException();
        }
    }
}
