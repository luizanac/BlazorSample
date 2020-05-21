using System;
using BlazorSample.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSample.Api.Configurations {
    public static class DatabaseSetup {
        public static void AddDatabaseSetup (this IServiceCollection services, IConfiguration configuration) {
            if (services == null) throw new ArgumentNullException (nameof (services));

            //Ef core in memory
            services.AddDbContext<ApplicationDbContext> (opt => opt.UseInMemoryDatabase ("TestDb"));
        }
    }
}