using entityFrameworkTest.Domain;
using System.Threading.Tasks;

namespace entityFrameworkTest.Services
{
    public interface IBulkAssemblingDataService
    {
        Task<SynthesisResult> BulkAssemblingData(Assembling assembling);
    }
}
