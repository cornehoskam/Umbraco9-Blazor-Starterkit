using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;

namespace Umbraco9.Core.Models.Miscellaneous
{
    public class CallToActionModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }

        public CallToActionModel() { }

        public CallToActionModel(Link link)
        {
            Title = link.Name;
            Url = link.Url;
            Target = link.Target;
        }
    }
}
