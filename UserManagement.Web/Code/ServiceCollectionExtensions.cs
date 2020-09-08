using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace UserManagement.Web.Code
{
    public static class ServiceCollectionExtensions
    {

      

        public static void AddCustomRequestLocalizationOptions(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(
               options =>
               {
                   var supportedCultures = new[]
                                               {
                                                  new CultureInfo("ar"), new CultureInfo("en"),
                                                  new CultureInfo("en-GB"), new CultureInfo("ar-SA")
                                                };

                    // State what the default culture for your application is. This will be used if no specific culture
                    // can be determined for a given request.
                    options.DefaultRequestCulture = new RequestCulture("en-GB", "en-GB");

                    // You must explicitly state which cultures your application supports.
                    // These are the cultures the app supports for formatting numbers, dates, etc.
                    options.SupportedCultures = supportedCultures;

                    // These are the cultures the app supports for UI strings, i.e. we have localized resources for.
                    options.SupportedUICultures = supportedCultures;
               });
        }
    }
}
