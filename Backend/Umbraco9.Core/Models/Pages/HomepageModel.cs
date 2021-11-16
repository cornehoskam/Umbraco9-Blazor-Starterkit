using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Umbraco9.Core.Helpers;
using Umbraco9.Core.Models.Elements;
using Umbraco9.Core.UmbracoModels;

namespace Umbraco9.Core.Models.Pages
{
    [Serializable]
    public class HomepageModel
    {
        public string Title { get; set; }

        public List<IElementModel> Elements { get; set; }

        public HomepageModel() { }

        public HomepageModel(Homepage umbHomepage)
        {
            Title = umbHomepage.Title;
            Elements = umbHomepage.BlockList.Select(x => x.GetCorrespondingElementModel()).ToList();
        }
    }
}
