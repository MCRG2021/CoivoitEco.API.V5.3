using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camping.API.Consume.Auth0.Service.Role.Queries;
using CovoitEco.API.Consume.Auth0.Interface.Role.Commands;
using CovoitEco.API.Consume.Auth0.Interface.Role.Queries;
using CovoitEco.API.Consume.Auth0.Interface.User.Commands;
using CovoitEco.API.Consume.Auth0.Interface.User.Queries;
using CovoitEco.API.Consume.Auth0.Service.Role.Commands;
using CovoitEco.API.Consume.Auth0.Service.User.Commands;
using CovoitEco.API.Consume.Auth0.Service.User.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CovoitEco.API.Consume.Auth0.ExtensionMethods
{
    public static class ServiceInjection
    {
        public static void AddAuth0Management(this IServiceCollection services)
        {
            services.AddHttpClient<IQueriesRoleService, QueriesRoleService>();
            services.AddHttpClient<ICommandsRoleService, CommandsRoleService>();
            services.AddHttpClient<ICommandsUserService, CommandsUserService>();
            services.AddHttpClient<IQueriesUserService, QueriesUserService>();
        }
    }
}
