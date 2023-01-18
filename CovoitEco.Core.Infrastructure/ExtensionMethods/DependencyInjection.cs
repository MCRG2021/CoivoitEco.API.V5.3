using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CovoitEco.Core.Infrastructure.ExtensionMethods
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DefaultContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("CovoitEcoDatabase"),
                    b => b.MigrationsAssembly(typeof(DefaultContext).Assembly.FullName)));


            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<DefaultContext>());
            return services;
        }
    }
}
