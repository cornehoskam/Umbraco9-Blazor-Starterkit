using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Umbraco9.Blazor.Services;

namespace Umbraco9.Blazor
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomBlazorServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<IContentDeliveryService, ContentDeliveryService>();
            return services;
        }
    }
}
