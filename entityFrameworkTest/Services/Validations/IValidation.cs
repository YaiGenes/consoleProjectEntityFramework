using entityFrameworkTest.Domain;

namespace entityFrameworkTest.Services.Validations
{
    public interface IValidation<T>
    {
        string TestName { get; }
        SynthesisResult Validate(T entity);
    }
}
