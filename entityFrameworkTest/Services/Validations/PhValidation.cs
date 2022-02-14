using entityFrameworkTest.Domain;
using System;
using System.Linq;


namespace entityFrameworkTest.Services.Validations
{
    public class PhValidation : IValidation<ValidationContext>
    {
        public string TestName => "pH test";
        public SynthesisResult Validate(ValidationContext entity)
        {
            SynthesisResult result = new SynthesisResult();
            var sourceComponent = entity.SourceComponents.SingleOrDefault(sr => sr.ProteinType == entity.Component.ProteinType);
            if (sourceComponent != null)
            {
                if (entity.Component.Ph != sourceComponent.Ph || entity.Component.Ubiquitination == false)
                {
                    result.AddError(200, $"Protein {entity.Component.ProteinType} has a pH out of its optimum level");
                }
            }
            else 
            {
                result.AddError(new NotSupportedException($"Protein {entity.Component.ProteinType} not found"));
            }
            return result;
        }
    }
}
