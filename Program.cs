using Microsoft.EntityFrameworkCore;
using ProyectoTFG.Componentes.Widgets.Toast;
using ProyectoTFG.Data;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<TrabajadorService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<CitasService>();
builder.Services.AddScoped<PacientesService>();
builder.Services.AddScoped<ToastService>();
builder.Services.AddSingleton<ToastService>();

var connectionString = builder.Configuration.GetConnectionString("HospitalDB");


builder.Services.AddDbContextFactory<HospitalContext>(options => options.UseSqlite(connectionString));

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1hXk5Hd0BLVGpAblJ3T2ZQdVt5ZDU7a15RRnVfR19qSXpTckFrXnxecQ==;Mgo+DSMBPh8sVXJ1S0R+X1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jTHxadkFjXXtWd3BTRw==;ORg4AjUWIQA/Gnt2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtRf0VnWXtaeHNTRmE=;MjIzMzY5MkAzMjMxMmUzMDJlMzBFSURRUFYwTXRMT2hnWHBxZU10VDdNNXkvYXc1RnBDVTNtZE5RR0RlclRFPQ==;MjIzMzY5M0AzMjMxMmUzMDJlMzBsWXpLTENvK05MVE5WOFhjQk1aWVJ1NEJlR0NuZTM2aVRJQW5OZS9PZ1Y0PQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5WdExjXX9adHxdRWdd;MjIzMzY5NUAzMjMxMmUzMDJlMzBZbnphL2pUOWl6K0hLNG1MODBhdzcxNjd3cXdwdXkrNW1iR25zVFNqTFlFPQ==;MjIzMzY5NkAzMjMxMmUzMDJlMzBCdlVFaUFEUko4bXo0WWtTdWt3TnY4dG1FWkdpQzdZV2NJcWVjSHlzRmNzPQ==;Mgo+DSMBMAY9C3t2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtRf0VnWXtaeH1VRGE=;MjIzMzY5OEAzMjMxMmUzMDJlMzBLbkRKRkJJL0J4VlpUWlRTejhicjJqYnZmaWM5WmtvMDBJVXFITHRkd2tvPQ==;MjIzMzY5OUAzMjMxMmUzMDJlMzBRb2VKNnFWZEFLNnhZdlg5N2tQeDdIdG9qRHdRTEZDVGs4U1g1cWNxK2JNPQ==;MjIzMzcwMEAzMjMxMmUzMDJlMzBZbnphL2pUOWl6K0hLNG1MODBhdzcxNjd3cXdwdXkrNW1iR25zVFNqTFlFPQ==");

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
