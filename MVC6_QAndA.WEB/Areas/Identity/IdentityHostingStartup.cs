using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC6_QAndA.WEB.Data;

[assembly: HostingStartup(typeof(MVC6_QAndA.WEB.Areas.Identity.IdentityHostingStartup))]
namespace MVC6_QAndA.WEB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppUserDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AppUserDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AppUserDbContext>();
            });
        }
    }
}