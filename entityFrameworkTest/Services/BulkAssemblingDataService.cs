using entityFrameworkTest.Data;
using entityFrameworkTest.Data.Repositories;
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
                Order = assembling.Order,
                Components = assembling.Components
                                    .Select(c =>
                                        new ComponentEntity
                                        {
                                            Ph = c.Ph,
                                            Temp = c.Temp,
                                            Id = Guid.NewGuid(),
                                            HSP80 = c.HSP80,
                                            Chaperonine = c.Chaperonine,
                                            EnergyIncrease = c.EnergyIncrease,
                                            Ubiquitination = c.Ubiquitination,
                                            NumComponents = c.NumComponents,
                                            ProteinType = c.ProteinType,
                                            Subcomponents = c.Subcomponents.Select(r => new SubcomponentEntity
                                            {
                                                Id = Guid.NewGuid(),
                                                Energy = (decimal)r.Energy,
                                                Type = r.Type
                                            }).ToList()
                                        }).ToList()
            };

            return assemblingEntity;
        }
    }
}
