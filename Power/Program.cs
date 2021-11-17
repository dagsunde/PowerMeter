using Power.Business;
using Power.Models;
using Power.Utils;
using Tibber.Sdk;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

GetPower();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static async Task<PowerModel> GetPower()
{
    var model = new PowerModel();

    var client = new TibberApiClient(Settings.GetSetting("Tokens", "TibberToken"));
    var basicData = await client.GetBasicData();
    var homeId = basicData.Data.Viewer.Homes.First().Id.Value;

    var listener = await client.StartRealTimeMeasurementListener(homeId);
    listener.Subscribe(new RealTimeMeasurementObserver());

    return model;

}

