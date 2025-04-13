using DubaiEstate.BLL.DependencyInjection;
using DubaiEstate.BLL.Jobs;
using DubaiEstate.DAL;
using DubaiEstate.DAL.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DubaiEstateLabContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddDatabaseLayerServices();
builder.Services.AddBusinessLogicLayerServices();
builder.Services.AddControllersWithViews();

builder.Services.AddHostedService<CubeProcessingBackgroundJob>();

builder.Services.AddMemoryCache();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Transactions/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Transactions}/{action=Index}");

app.Run();
