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

var builder = WebApplication.CreateBuilder(args);

//extensions metod katmanlar kendi baðýmlýklarýný enjekte ediyor
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

app.UseAuthorization();

app.MapControllers();

app.Run();