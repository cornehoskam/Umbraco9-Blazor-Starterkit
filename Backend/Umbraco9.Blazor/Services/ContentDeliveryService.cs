using Microsoft.Extensions.Configuration;
using NPoco.fastJSON;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Umbraco9.Core.Models.Pages;
using Umbraco9.Core.Services;

namespace Umbraco9.Blazor.Services
{
    public class ContentDeliveryService : IContentDeliveryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        private Dictionary<string, object> ContentCache { get; set; }

        public ContentDeliveryService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            ContentCache = new Dictionary<string, object>();
        }

        public async Task<T> GetPageOfType<T>(string urlSegment) where T : class
        {
            try
            {
                var cachedObject = ContentCache.ContainsKey(urlSegment);
                if (cachedObject)
                {
                    return (T)ContentCache[urlSegment];
                }

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
                    var parsedObject = JSON.ToObject<T>(readStream);

                    ContentCache[urlSegment] = parsedObject;

                    return (T)parsedObject;
                }

                return default;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default;
            }
        }

        public async Task<HomepageModel> GetHomePage()
        {
            return await GetPageOfType<HomepageModel>("/");
        }
    }
}
