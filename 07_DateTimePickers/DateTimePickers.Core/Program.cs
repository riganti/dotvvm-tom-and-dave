using DateTimePickers.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDotVVM<DotvvmStartup>();

var app = builder.Build();

app.UseDotVVM<DotvvmStartup>();

app.Run();