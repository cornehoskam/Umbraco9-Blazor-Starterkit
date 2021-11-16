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
    public class ParagraphElementModel : IElementModel
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string UmbracoContentType => ParagraphElement.ModelTypeAlias;

        public ParagraphElementModel() { }

        public ParagraphElementModel(ParagraphElement paragraphElement)
        {
            Title = paragraphElement.Title;
            Text = paragraphElement.Text.ToHtmlString();
        }
    }
}
