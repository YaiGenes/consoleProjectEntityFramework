using entityFrameworkTest.Domain;
namespace entityFrameworkTest.Services
{
    public interface IGolgiOrderProcessor
    {
        SynthesisResult<Assembling> Process(string processFile);
    }
}
