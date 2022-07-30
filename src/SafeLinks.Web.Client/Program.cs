using SafeLinks.Core.Application.Extensions;
using SafeLinks.Infrastructure.Extensions;
using SafeLinks.Web.Client.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddWebClientServices();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
