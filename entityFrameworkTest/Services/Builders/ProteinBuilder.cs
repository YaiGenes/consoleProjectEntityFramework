using entityFrameworkTest.Domain;
using entityFrameworkTest.Dto;
using System.Linq;

namespace entityFrameworkTest.Services.Builders
{
    public class ProteinBuilder
    {
        public static ProteinBuilder CreateBuilderFrom(MolecularComponentsDTO dto)
        {
            Component component = new Component()
            {
                ProteinType = dto.ProteinType,
                EnergyIncrease = dto.EnergyIncrease,
                NumComponents = dto.NumComponents,
                Chaperonine = dto.Checkpoint.Chaperonine,
                HSP80 = dto.Checkpoint.HSP80,
                Ubiquitination = dto.Checkpoint.Ubiquitination,
                Subcomponents = dto.Subcomponents.Select(sc => new SubcomponentDTO
                {
                    Energy = sc.Energy,
                    Type = sc.Type,
                }).ToList(),
            };

            return new ProteinBuilder(component);
        }

        private readonly Component _component;

        private ProteinBuilder(Component component)
        {
            _component = component;
        }

        public ProteinBuilder AddTermicProtection() 
        {
            _component.HSP80 = true;
            return this;
        }

        public bool CheckTemp(double temp)
        {
            if (_component.Temp == temp)
            {
                return true;
            }
            return false;
        }

        //ph and temp checks the state of naturalization of protein, if the get it value is different there will be assembling issues

        public Component Build()
        {
            return _component;
        }

    }
}
