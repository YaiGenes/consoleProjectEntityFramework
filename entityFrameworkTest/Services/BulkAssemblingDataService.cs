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
        private readonly IAssemblyRepository _packageRepository;

        public BulkAssemblingDataService(IAssemblyRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<SynthesisResult> BulkPackageData(Assembly package)
        {
            var packageEntity = MapPackage(package);

            _packageRepository.Add(packageEntity);

            await _packageRepository.SaveChanges();

            return new SynthesisResult();
        }

        private AssemblyEntity MapPackage(Assembly package)
        {
            AssemblyEntity packageEntity = new AssemblyEntity()
            {
                Id = Guid.NewGuid(),
                OrderCode = package.OrderCode,
                Components = package.Components
                                    .Select(c =>
                                        new ComponentEntity
                                        {
                                            Brand = c.Brand,
                                            Color = c.Color,
                                            Id = Guid.NewGuid(),
                                            IsPolished = c.IsPolished,
                                            Number = c.NumComponents,
                                            Type = c.ComponentType,
                                            Subcomponents = c.Subcomponents.Select(r => new SubcomponentEntity
                                            {
                                                Id = Guid.NewGuid(),
                                                Price = (decimal)r.Price,
                                                Type = r.Type
                                            }).ToList()
                                        }).ToList()
            };

            return packageEntity;
        }
    }
}
