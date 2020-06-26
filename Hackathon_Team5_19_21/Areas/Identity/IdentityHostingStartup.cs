using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Hackathon_Team5_19_21.Areas.Identity.IdentityHostingStartup))]
namespace Hackathon_Team5_19_21.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}