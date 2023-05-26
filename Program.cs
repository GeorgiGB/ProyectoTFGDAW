using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Data;
using ProyectoTFG.Data.Toast;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<ToastService>();

var connectionString = builder.Configuration.GetConnectionString("HospitalDB");


builder.Services.AddDbContextFactory<HospitalContext>(options => options.UseSqlite(connectionString));

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA0NDM3NkAzMjMwMmUzNDJlMzBZZkNQVElRZzdLbFkyRmhGcldRL3VSUDBMeVEwL2k0R3JicDFFRGJqNUpBPQ==");

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
