using Business.Abstracts;
using Business.Concrates;
using Core.crossCuttingConcerns.Exceptions;
using DataAccess.Abstracts;
using DataAccess.Concrates.EntityFramework;
using DataAccess.Concretes.EntityFramework;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using System.Reflection;
using Business;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using WebApi;
using TokenOptions = Core.Utilities.JWT.TokenOptions;
using Core.Utilities.Encryption;
using Core;


var builder = WebApplication.CreateBuilder(args);

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();


//extensions metod katmanlar kendi baðýmlýklarýný enjekte ediyor
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices();
builder.Services.AddCoreServices(tokenOptions);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var getValue = builder.Configuration.GetSection("TokenOptions").GetValue<string>("SecurityKey");


builder.Services.
    AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //jwt config
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//extensions metod kullanarak projeyi tek satýrda dahil ettik
app.ConfigureExceptionMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Commit && push deneme