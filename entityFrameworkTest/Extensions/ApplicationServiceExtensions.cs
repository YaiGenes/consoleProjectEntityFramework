using Microsoft.EntityFrameworkCore;
using entityFrameworkTest.Data.Repositories;
using entityFrameworkTest.Domain;
using entityFrameworkTest.Services;
using entityFrameworkTest.Services.Handlers;
using entityFrameworkTest.Services.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
                var types = new string[] { "hemoglobine" };

                Action<ComponentContext> action = (context) => context.Component.Ph = context.Ph;
                Handler<ComponentContext> prevHandler = null;

                foreach (var type in types)
                {
                    prevHandler = new Handler<ComponentContext>(x => x.Component.ProteinType == type, action, prevHandler);
                }

                return prevHandler;
            });

            services.AddDbContextPool<GolgiDbContext>((provider, builder) =>
            {
                builder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                //builder.UseInMemoryDatabase("proteinsynthesis");
                builder.UseSqlServer(configuration.GetConnectionString("people"));
            });

            services.AddTransient<IAssemblingRepository, AssemblingRepository>();
            services.AddTransient<IComponentRepository, ComponentRepository>();
            services.AddTransient<ISubComponentRepository, SubComponentRepository>();

            return services;
        }
    }
}
