using entityFrameworkTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Services
{
    public class BulkAssemblingDataService : IBulkAssemblingDataService
    {
        private readonly IAssemblingRepository _assemblingRepository;

        public BulkAssemblingDataService(IAssemblingRepository assemblingRepository)
        {
            _assemblingRepository = assemblingRepository;
        }

        public async Task<SynthesisResult> BulkAssemblingData(Assembling assembling)
        {
            var assemblingEntity = MapAssambling(assembling);

            _assemblingRepository.Add(assemblingEntity);

            await _assemblingRepository.SaveChanges();

            return new SynthesisResult();
        }

        private AssemblingEntity MapAssambling(Assembling assembling)
        {
            AssemblingEntity assemblingEntity = new AssemblingEntity()
            {
                Id = Guid.NewGuid(),
                OrderCode = assembling.Order,
                Component = assembling.Components
                                    .Select(c =>
                                        new ComponentEntity
                                        {
                                            ph = c.Ph,
                                            Temp = c.Temp,
                                            Id = Guid.NewGuid(),
                                            HSP80 = c.HSP80,
                                            Chaperonine = c.Chaperonine,
                                            Ubiquitination = c.Ubiquitination,
                                            Number = c.NumComponents,
                                            Type = c.ProteinType,
                                            Subcomponents = c.Subcomponents.Select(r => new SubcomponentEntity
                                            {
                                                Id = Guid.NewGuid(),
                                                EnergyCost = (decimal)r.Energy,
                                                Type = r.Type
                                            }).ToList()
                                        }).ToList()
            };

            return assemblingEntity;
        }
    }
}
