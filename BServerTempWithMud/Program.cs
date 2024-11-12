using BServerTempWithMud.Components;
using BServerTempWithMud.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using BServerTempWithMud.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();
builder.Services.AddMudServices();

builder.Services.AddDbContextFactory<MyDbContext>((service, option) =>
{
	var conf = service.GetRequiredService<IConfiguration>();
	string ConnectionString = conf.GetConnectionString("MyDB");
	option.UseSqlServer(ConnectionString);
});

builder.Services.AddTransient<IUserServices,UserServices>();	
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
