using FluentValidation.AspNetCore;
using LinearSistemas.CanaisVendas.Application;
using LinearSistemas.CanaisVendas.Application.Behaviours;
using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddCanalVenda;
using LinearSistemas.CanaisVendas.Infra;
using LinearSistemas.CanaisVendas.Infra.Context;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseSetup(builder.Configuration);
builder.Services.AddDependencyInjectionSetup();
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VendasContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
