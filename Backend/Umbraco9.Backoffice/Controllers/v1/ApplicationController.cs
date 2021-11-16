using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NPoco.fastJSON;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.UmbracoContext;
using Umbraco.Extensions;
using Umbraco9.Core.Models.Pages;
using Umbraco9.Core.UmbracoModels;

namespace Umbraco9.Backoffice.Controllers.v1
{
    [Route("api/v1/application/[action]")]
    public class ApplicationController : UmbracoApiController
    {
        private readonly IConfiguration _configuration;

        private readonly IUmbracoHelperAccessor _umbracoHelperAccessor;
        public ApplicationController(IConfiguration configuration, IUmbracoHelperAccessor umbracoHelperAccessor)
        {
            _configuration = configuration;
            _umbracoHelperAccessor = umbracoHelperAccessor;
        }

        public string GetVersion()
        {
            return _configuration["Application:Version"];
        }

        public ActionResult GetHomepage()
        {
            if (_umbracoHelperAccessor.TryGetUmbracoHelper(out var umbracoHelper) is false)
            {
                return StatusCode(500);
            }

            var rootNode = umbracoHelper.ContentAtRoot().FirstOrDefault();
            if (rootNode is null)
            {
                return NotFound();
            }

            var homePage = rootNode.FirstChild<Homepage>();
            if (homePage is null)
            {
                return NotFound();
            }

            return new ContentResult()
            {
                Content = JSON.ToNiceJSON(new HomepageModel(homePage))
            };
        }
    }
}
