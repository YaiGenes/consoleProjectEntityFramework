using Microsoft.EntityFrameworkCore;
using entityFrameworkTest.Data.Repositories;
using entityFrameworkTest.Domain;
using entityFrameworkTest.Services;
using entityFrameworkTest.Services.Handlers;
using entityFrameworkTest.Services.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IValidation<ValidationContext>, PhValidation>();
            services.AddTransient<IValidation<ValidationContext>, TermicValidation>();
            services.AddTransient<IGolgiOrderProcessor, GolgiOrderProcessor>();
            services.AddTransient<IBulkAssemblingDataService, BulkAssemblingDataService>();

            services.AddSingleton<IHandler<ComponentContext>>(c =>
            {
                var types = new string[] { "hemoglobine", "Pistón", "Biela", "Cigüenal", "Embrague", "Cartel" };

                Action<ComponentContext> action = (context) => context.Component.Ph = context.Ph;
                Handle<ComponentContext> prevHandler = null;

                foreach (var type in types)
                {
                    prevHandler = new Handle<ComponentContext>(x => x.Component.ProteinType == type, action, prevHandler);
                }

                return prevHandler;
            });

            services.AddDbContextPool<GolgiDbContext>((provider, builder) =>
            {
                builder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                builder.UseSqlServer(configuration.GetConnectionString("people"));
            });

            services.AddTransient<IAssemblingRepository, AssemblingRepository>();
            services.AddTransient<IComponentRepository, ComponentRepository>();
            services.AddTransient<ISubComponentRepository, SubComponentRepository>();

            return services;
        }
    }
}
