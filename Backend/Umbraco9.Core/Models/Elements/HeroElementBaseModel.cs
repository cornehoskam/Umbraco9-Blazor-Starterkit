using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Umbraco9.Core.UmbracoModels;

namespace Umbraco9.Core.Models.Elements
{
    [Serializable]
    public class HeroElementBaseModel : IElementModel
    {
        public string Title { get; set; }
        public string Subtext { get; set; }
        public string CallToAction { get; set; } //Todo make Link model
        public string ContentType => "HeroElement";

        public HeroElementBaseModel() { }

        public HeroElementBaseModel(HeroElement heroElement)
        {
            Title = heroElement.Title;
            Subtext = heroElement.Subtext;
            CallToAction = heroElement.CallToAction?.Url;
        }
    }
}
