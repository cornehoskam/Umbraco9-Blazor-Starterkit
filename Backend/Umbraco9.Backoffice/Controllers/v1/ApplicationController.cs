using Microsoft.AspNetCore.Mvc;
using NPoco.fastJSON;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco9.Core.Models.Pages;
using Umbraco9.Core.Services;

namespace Umbraco9.Backoffice.Controllers.v1
{
    [Route("api/v1/application/[action]")]
    public class ApplicationController : UmbracoApiController
    {
        private readonly IConfiguration _configuration;

        private readonly IContentDeliveryService contentDeliveryService;

        public ApplicationController(
            IConfiguration configuration,
            IContentDeliveryService contentDeliveryService)
        {
            _configuration = configuration;
            this.contentDeliveryService = contentDeliveryService;
        }

        public string GetVersion()
        {
            return _configuration["Application:Version"];
        }

        public async Task<ActionResult> GetHomepage()
        {
            var result = await contentDeliveryService.GetHomePage();

            if (result == null)
            {
                return NotFound();
            }

            return new ContentResult()
            {
                Content = JSON.ToNiceJSON(result)
            };
        }

        public async Task<ActionResult> GetGenericContentPage(string contentPageUrlSegment)
        {
            var result = await contentDeliveryService.GetPageOfType<GenericContentPageModel>(contentPageUrlSegment);

            if (result == null)
            {
                return NotFound();
            }

            return new ContentResult()
            {
                Content = JSON.ToNiceJSON(result)
            };
        }

    }
}
