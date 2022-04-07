using Umbraco.Cms.Web.Common;
using Umbraco.Extensions;
using Umbraco9.Core.Models.Pages;
using Umbraco9.Core.Services;
using Umbraco9.Core.UmbracoModels;

namespace Umbraco9.Backoffice.Services
{
    public class BackofficeContentDeliveryService : IContentDeliveryService
    {
        private readonly IUmbracoHelperAccessor _umbracoHelperAccessor;

        public BackofficeContentDeliveryService(IUmbracoHelperAccessor umbracoHelperAccessor)
        {
            _umbracoHelperAccessor = umbracoHelperAccessor;
        }

        public async Task<T?> GetPageOfType<T>(string urlSegment) where T : class
        {
            if (typeof(T) == typeof(HomepageModel))
            {
                var homePage = await GetHomePage();
                return homePage as T;
            }

            if (typeof(T) == typeof(GenericContentPageModel))
            {
                var contentPage = GetGenericContentPage(urlSegment);
                return contentPage as T;
            }

            return default;
        }

        public Task<HomepageModel> GetHomePage()
        {
            if (_umbracoHelperAccessor.TryGetUmbracoHelper(out var umbracoHelper) is false)
            {
                throw new Exception("Unable to get Umbraco Helper");
            }

            HomepageModel? result = null;

            var rootNode = umbracoHelper.ContentAtRoot().FirstOrDefault();
            if (rootNode is null)
            {
                return Task.FromResult(result);
            }

            var homePage = rootNode.FirstChild<Homepage>();
            if (homePage is null)
            {
                return Task.FromResult(result);
            }

            result = new HomepageModel(homePage);
            return Task.FromResult(result);
        }

        public GenericContentPageModel? GetGenericContentPage(string contentPageUrlSegment)
        {
            if (_umbracoHelperAccessor.TryGetUmbracoHelper(out var umbracoHelper) is false)
            {
                throw new Exception("Unable to get Umbraco Helper");
            }

            var rootNode = umbracoHelper.ContentAtRoot().FirstOrDefault();
            if (rootNode is null)
            {
                return null;
            }

            var contentPage = rootNode.Descendants<GenericContentPage>()
                .FirstOrDefault(x => x.UrlSegment == contentPageUrlSegment ||
                                     x.UrlSegment + "/" == contentPageUrlSegment);
            if (contentPage is null)
            {
                return null;
            }

            return new GenericContentPageModel(contentPage);
        }
    }
}
