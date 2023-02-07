using Grand.Business.Core.Interfaces.Common.Pdf;
using Grand.Infrastructure;
using Grand.Web.Common.Menu;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Misc.CzechInvoiceGenerator.Services;

namespace Misc.CzechInvoiceGenerator
{
    public class StartupApplication : IStartupApplication
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Replace(ServiceDescriptor.Scoped<IPdfService, CzechPdfService>());

            services.AddScoped<IInvoiceSeriesService, InvoiceSeriesService>();

            services.AddScoped<IAdminMenuProvider, CzechInvoiceGeneratorMenuProvider>();
        }

        public int Priority => 200;

        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {
            
        }

        public bool BeforeConfigure => false;
    }

}
