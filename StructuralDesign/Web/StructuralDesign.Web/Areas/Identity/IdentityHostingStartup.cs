using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(StructuralDesign.Web.Areas.Identity.IdentityHostingStartup))]

namespace StructuralDesign.Web.Areas.Identity
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