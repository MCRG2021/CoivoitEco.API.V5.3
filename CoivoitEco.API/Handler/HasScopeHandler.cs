using CovoitEco.Core.Application.Filter;
using Microsoft.AspNetCore.Authorization;

namespace CoivoitEco.API.Handler
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            // check email user
            var user = context.User.FindAll(c => c.Type == "emailUser");
            var userResult = string.Join("", user);
            EmailAuthorizationCheck.email = Extract(userResult);

            var permissions = context.User.FindAll(c => c.Type == "permissions");
            var result = string.Join(",", permissions);
            if (result.Contains(requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
        private string Extract(string mail)
        {
            char[] spearator = { ' ', ':' };

            String[] resultSplit = mail.Split(spearator);

            return resultSplit[2];
        }
    }
}



