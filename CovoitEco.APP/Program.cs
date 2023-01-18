using Blazored.Toast;
using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP;
using CovoitEco.APP.Extensions;
using CovoitEco.APP.Service.Annonce.Commands;
using CovoitEco.APP.Service.Annonce.Queries;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using PeterLeslieMorris.Blazor.Validation;
//using PeterLeslieMorris.Blazor.FluentValidation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("CovoitEcoAuth0API", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("CovoitEcoAuth0API"));

builder.Services.AddServices();

builder.Services.AddBlazoredToast(); // Toast

// Authentication part
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
});


await builder.Build().RunAsync();

