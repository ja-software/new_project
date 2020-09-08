using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(UserManagement.Web.Areas.Identity.IdentityHostingStartup))]
namespace UserManagement.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}