using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmojiChat.Web;
using EmojiChat.Web.Hubs;
using EmojiChat.Web.Services;
using OpenAI;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton(
    new OpenAIClient(builder.Configuration.GetSection("OpenAI:ApiKey").Value)
        .GetOpenAIResponseClient("gpt-5-nano"));
builder.Services.AddSingleton<ChatService>();

builder.Services.AddAuthentication();
builder.Services.AddDotVVM<DotvvmStartup>();

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

app.MapHub<ChatHub>("/hubs/ai");

app.Run();