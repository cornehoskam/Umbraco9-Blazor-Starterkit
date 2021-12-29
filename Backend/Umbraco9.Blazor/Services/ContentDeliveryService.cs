using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NPoco.fastJSON;
using Umbraco9.Core.Models.Pages;
using Umbraco9.Core.UmbracoModels;

namespace Umbraco9.Blazor.Services
{
    public class ContentDeliveryService : IContentDeliveryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public ContentDeliveryService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<T> GetPageOfType<T>(string urlSegment = "")
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var baseUrl = _configuration["cms:hostUrl"];

                HttpResponseMessage response = null;

                if (typeof(T) == typeof(HomepageModel))
                {
                    response = await client.GetAsync(($"{baseUrl}api/v1/application/getHomepage"));
                }
                if (typeof(T) == typeof(GenericContentPageModel))
                {
                    response = await client.GetAsync(($"{baseUrl}api/v1/application/GetGenericContentPage?contentPageUrlSegment={urlSegment}"));
                }

                if (response is { IsSuccessStatusCode: true })
                {
                    var readStream = await response.Content.ReadAsStringAsync();
                    return JSON.ToObject<T>(readStream);
                }

                return default;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default;
            }
        }
    }
}
