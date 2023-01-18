using Microsoft.AspNetCore.Authorization;

namespace CoivoitEco.API.Handler
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            var permissions = context.User.FindAll(c => c.Type == "permissions");
            var result = string.Join(",", permissions);
            if (result.Contains(requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

//Sign up

//    ${footerLinkText}

//Don 't have an account?



//{
//    "pageTitle": "Log in | ${clientName}",
//    "title": "Welcome",
//    "description": "Log in to ${companyName} to continue to ${clientName}.",
//    "separatorText": "Or",
//    "buttonText": "Continue",
//    "federatedConnectionButtonText": "Continue with ${connectionName}",
//    "footerLinkText": "Sign up",
//    "signupActionLinkText": "${footerLinkText}",
//    "footerText": "Don't have an account?",
//    "signupActionText": "${footerText}",
//    "forgotPasswordText": "Forgot password?",
//    "passwordPlaceholder": "Password",
//    "usernamePlaceholder": "Username or email address",
//    "emailPlaceholder": "Email address",
//    "editEmailText": "Edit",
//    "alertListTitle": "Alerts",
//    "invitationTitle": "You've Been Invited!",
//    "invitationDescription": "Log in to accept ${inviterName}'s invitation to join ${companyName} on ${clientName}.",
//    "logoAltText": "${companyName}",
//    "showPasswordText": "Show password",
//    "hidePasswordText": "Hide password",
//    "wrong-credentials": "Wrong username or password",
//    "invalid-code": "The code you entered is invalid",
//    "invalid-expired-code": "Invalid or expired user code",
//    "invalid-email-format": "Email is not valid.",
//    "wrong-email-credentials": "Wrong email or password",
//    "custom-script-error-code": "Something went wrong, please try again later.",
//    "auth0-users-validation": "Something went wrong, please try again later",
//    "authentication-failure": "We are sorry, something went wrong when attempting to login",
//    "invalid-connection": "Invalid connection",
//    "ip-blocked": "We have detected suspicious login behavior and further attempts will be blocked. Please contact the administrator.",
//    "no-db-connection": "Invalid connection",
//    "password-breached": "We have detected a potential security issue with this account. To protect your account, we have prevented this login. Please reset your password to proceed.",
//    "user-blocked": "Your account has been blocked after multiple consecutive login attempts.",
//    "same-user-login": "Too many login attempts for this user. Please wait, and try again later.",
//    "no-email": "Please enter an email address",
//    "no-password": "Password is required",
//    "no-username": "Username is required"
//}