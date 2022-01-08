using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Umbraco.Cms.Core.Strings;
using Umbraco9.Core.Models.Miscellaneous;
using Umbraco9.Core.UmbracoModels;

namespace Umbraco9.Core.Models.Elements
{
    [Serializable]
    public class FaqElementModel : IElementModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<FaqItemModel> QuestionsAnswers { get; set; }

        public string UmbracoContentType => FAqelement.ModelTypeAlias;

        public FaqElementModel() { }

        public FaqElementModel(FAqelement faqElement)
        {
            Title = faqElement.Title;
            Description = faqElement.Description.ToHtmlString();

            if (faqElement.QuestionsAnswers != null && faqElement.QuestionsAnswers.Any())
               QuestionsAnswers = faqElement.QuestionsAnswers.Where(x => x is FaqItem).Select(x => new FaqItemModel(x as FaqItem)).ToList();
        }
    }
}
