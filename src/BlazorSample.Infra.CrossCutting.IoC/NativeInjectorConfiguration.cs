using BlazorSample.Domain.Interfaces.UoW;
using BlazorSample.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSample.Infra.CrossCutting.IoC {
    public class NativeInjectorConfiguration {

        public static void RegisterServices (IServiceCollection services) {

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork> ();
        }

    }
}