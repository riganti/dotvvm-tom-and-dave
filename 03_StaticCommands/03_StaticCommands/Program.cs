using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotVVM.Framework.Hosting;

using StaticCommands;
using StaticCommands.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication();
builder.Services.AddDotVVM<DotvvmStartup>();
builder.Services.AddScoped<FileService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.UseDotVVM<DotvvmStartup>();
app.MapDotvvmHotReload();

app.Run();