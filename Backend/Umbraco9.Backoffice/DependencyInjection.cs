using Umbraco9.Backoffice.Services;
using Umbraco9.Core.Services;

namespace Umbraco9.Backoffice
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomBlazorServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<IContentDeliveryService, BackofficeContentDeliveryService>();
            return services;
        }
    }
}
