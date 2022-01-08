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
        public static IElementModel GetCorrespondingElementModel(this BlockListItem element)
        {
            switch (element.Content)
            {
                case HeroElement heroElement:
                    return new HeroElementModel(heroElement);
                case ParagraphElement paragraphElement:
                    return new ParagraphElementModel(paragraphElement);
                case FAqelement faqElement:
                    return new FaqElementModel(faqElement);
                case TestimonialElement testimonialElement:
                    return new TestimonialElementModel(testimonialElement);
                case ChartElement chartElement:
                    return new ChartElementModel(chartElement);
                default:
                    return null;
            }
        }
    }
}
