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
    public class GenericContentPageModel
    {
        public string Title { get; set; }

        public List<IElementModel> Elements { get; set; }

        public GenericContentPageModel() { }

        public GenericContentPageModel(GenericContentPage umbContentPage)
        {
            Title = umbContentPage.Title;
            Elements = umbContentPage.BlockList.Select(x => x.GetCorrespondingElementModel()).ToList();
        }
    }
}
