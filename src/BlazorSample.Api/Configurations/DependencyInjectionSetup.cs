using System;
using BlazorSample.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSample.Api.Configurations {
    public static class DependencyInjectionSetup {
        public static void AddDependencyInjectionSetup (this IServiceCollection services) {
            if (services == null) throw new ArgumentNullException (nameof (services));

            NativeInjectorConfiguration.RegisterServices (services);
        }
    }
}