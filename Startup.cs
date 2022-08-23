using LeagueClient.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace LeagueClient
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<LeagueClientContext>(options => options.UseSqlServer("ConnectionString:Server=DESKTOP-PO0GU27\\SQLEXPRESS;Database=LeagueClient;Trusted_Connection=True;"));
        }
    }
}
