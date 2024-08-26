using cls.web.plataforma.Configs;
using cls.web.plataforma.Data.Interface;
using cls.web.plataforma.Data.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.Configure<Configurations>(config =>
{
    config.Version = builder.Configuration.GetSection("VERSION_APP").Value ?? "0";
});

builder.Services.AddHttpClient();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddSingleton<IOptionsConfig, OptionsConfig>();

builder.Services.AddScoped<ISessionContext, SessionContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
