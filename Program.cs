using LeagueClient.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

//"Server=DESKTOP-PO0GU27\\SQLEXPRESS;Database=LeagueClient;Trusted_Connection=True;"
//Data Source=DESKTOP-PO0GU27\\SQLEXPRESS;Initial Catalog=LeagueClient;Integrated Security=True
// Add services to the container.
builder.Services.AddDbContext<LeagueClientContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddScoped<IServiceCollection, ServiceCollection>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
