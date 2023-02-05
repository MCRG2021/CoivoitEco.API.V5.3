using CoivoitEco.API.Handler;
using CoivoitEco.API.Middlewares;
using CovoitEco.API.Consume.Auth0.ExtensionMethods;
using CovoitEco.Core.Application.ExtensionMethods;
using CovoitEco.Core.Infrastructure.ExtensionMethods;
using CovoitEco.Core.Infrastructure.Loggers;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var domain = $"https://{configuration["Auth0:Domain"]}/";

// Add services to the container.
builder.Services.AddControllers();
builder.Logging.AddProvider(new CustomLoggerProvider());

// Security part 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
    {
        c.Authority = domain;
        c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidAudience = configuration["Auth0:Audience"],
            ValidIssuer = domain
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
    options.AddPolicy("write:messages", policy => policy.Requirements.Add(new HasScopeRequirement("write:messages", domain)));
    options.AddPolicy("read:users", policy => policy.Requirements.Add(new HasScopeRequirement("read:users", domain)));
    options.AddPolicy("write:users", policy => policy.Requirements.Add(new HasScopeRequirement("write:users", domain)));
});
builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CovoitEco", Version = "v1" });
});

builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();
builder.Services.AddAuth0Management();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters(); // not tested again => replace the code up 

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });


// Allow all (Cors)
var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7005")
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseRouting(); 

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();