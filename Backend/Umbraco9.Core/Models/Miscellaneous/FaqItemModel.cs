using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco9.Core.UmbracoModels;

namespace Umbraco9.Core.Models.Miscellaneous
{
    public class FaqItemModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool ShowAnswer { get; set; }

        public FaqItemModel() { }

        public FaqItemModel(FaqItem faqItem)
        {
            Question = faqItem.Question;
            Answer = faqItem.Answer.ToHtmlString();
        }
    }
}
