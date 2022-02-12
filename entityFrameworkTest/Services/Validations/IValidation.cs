using entityFrameworkTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Services.Validations
{
    public interface IValidation<T>
    {
        string TestName { get; }
        SynthesisResult Validate(T entity);
    }
}
