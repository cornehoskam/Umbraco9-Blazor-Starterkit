using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco9.Core.Models.Elements;
using Umbraco9.Core.UmbracoModels;

namespace Umbraco9.Core.Helpers
{
    public static class ElementModelMapper
    {
        public static object GetCorrespondingElementModel(this BlockListItem element)
        {
            if (element.Content is HeroElement heroElement)
            {
                return new HeroElementModel(heroElement);
            }

            return null;
        }
    }
}
