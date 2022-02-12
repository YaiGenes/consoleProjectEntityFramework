using entityFrameworkTest.Domain;
using entityFrameworkTest.Dto;
using entityFrameworkTest.Services.Builders;
using entityFrameworkTest.Services.Handlers;
using entityFrameworkTest.Services.Validations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Services
{
    public class GolgiOrderProcessor : IGolgiOrderProcessor
    {
        private readonly ILogger<GolgiOrderProcessor> logger;
        private readonly IHandler<ComponentContext> handler;
        private readonly IEnumerable<IValidation<ValidationContext>> validations;

        public GolgiOrderProcessor(ILogger<GolgiOrderProcessor> logger, IHandler<ComponentContext> handler, IEnumerable<IValidation<ValidationContext>> validations)
        {
            this.logger = logger;
            this.handler = handler;
            this.validations = validations;
        }

        public SynthesisResult<Assembling> Process(string processFile)
        {
            SynthesisResult<Assembling> synthesisResult = new SynthesisResult<Assembling>();

            try
            {
                var order = GetOrderData(processFile);

                var componentContexts = GetComponentContexts(order).ToList();

                ProcessTemp(componentContexts);

                var componentList = componentContexts.Select(c => c.Component);

                var result = ValidateOrder(order.Detail, componentList);

                if (result.Errors.Count > 0)
                {
                    synthesisResult.Errors.AddRange(result.Errors);
                }
                else
                {
                    Assembling assembling = new Assembling(componentList) { Order = order.Order };
                    synthesisResult.Result = assembling;
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                synthesisResult.AddError(e);
            }
            return synthesisResult;
        }

        private void ProcessTemp(IEnumerable<ComponentContext> componentContexts)
        {
            foreach (var componentContext in componentContexts)
            {
                handler.Handle(componentContext);
            }
        }

        private SynthesisResult ValidateOrder(IEnumerable<MolecularComponentsDTO> sourceComponents, IEnumerable<Component> components)
        {
            SynthesisResult result = new SynthesisResult();

            var validationContexts = components.Select(c => new ValidationContext { Component = c, SourceComponents = sourceComponents }).ToList();
            
            foreach (var validationContext in validationContexts)
            {
                var filteredValidations = validations.Where(c => validationContext.Component.Tests.Contains(c.TestName)); //filtrado de validaciones

                foreach (var validation in filteredValidations)
                {
                    var validationResult = validation.Validate(validationContext);
                    result.Errors.AddRange(validationResult.Errors);
                }
            }

            return result;
        }

        private IEnumerable<ComponentContext> GetComponentContexts(GolgiComplexDto order)
        {
            return order.Detail.Select(c => new ComponentContext
            {
                Component = ProteinBuilder.CreateBuilderFrom(c)
                .Build(),
                Temp = c.Temp,
                Ph = c.Ph
                
                
            });
        }

        private GolgiComplexDto GetOrderData(string jsonFile)
        {
            var webClient = new WebClient();
            var stringJson = webClient.DownloadString(jsonFile);
            DataDTO myDeserializedClass = JsonConvert.DeserializeObject<DataDTO>(stringJson);
            return (GolgiComplexDto)myDeserializedClass.Data;
        }
    }
}
