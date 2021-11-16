using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NPoco.fastJSON;
using Umbraco9.Core.Models.Pages;

namespace Umbraco9.Blazor.Services
{
    public class ContentDeliveryService : IContentDeliveryService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ContentDeliveryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HomepageModel> GetHomepage()
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var response = await client.GetAsync(("http://localhost:13457/api/v1/application/getHomepage"));
                if (response.IsSuccessStatusCode)
                {
                    var readStream = response.Content.ReadAsStringAsync().Result;
                    return JSON.ToObject<HomepageModel>(readStream);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
