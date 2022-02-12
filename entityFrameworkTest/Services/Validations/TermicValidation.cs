using entityFrameworkTest.Domain;
using System;
using System.Linq;

namespace entityFrameworkTest.Services.Validations
{
    public class TermicValidation : IValidation<ValidationContext>
    {
        public string TestName => "Termic test";

        public SynthesisResult Validate(ValidationContext entity)
        {
            SynthesisResult result = new SynthesisResult();
            var sourceComponent = entity.SourceComponents.SingleOrDefault(sr => sr.ProteinType == entity.Component.ProteinType);
            if (sourceComponent != null)
            {
                if (entity.Component.Temp != sourceComponent.Temp || entity.Component.HSP80 == false || entity.Component.Chaperonine == false)
                {
                    result.AddError(200, $"Protein {entity.Component.ProteinType} has a temperature out of its optimum level");
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
