using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco9.Core.Models.Miscellaneous;
using Umbraco9.Core.UmbracoModels;

namespace Umbraco9.Core.Models.Elements
{
    [Serializable]
    public class TestimonialElementModel : IElementModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public List<TestimonialItemModel> Testimonials {get; set;}
        public string UmbracoContentType => TestimonialElement.ModelTypeAlias;

        public TestimonialElementModel() { }

        public TestimonialElementModel(TestimonialElement testimonialElement) 
        {
            Title = testimonialElement.Title;
            Subtitle = testimonialElement.Subtitle;
            if(testimonialElement.Testimonials != null && testimonialElement.Testimonials.Any())
               Testimonials = testimonialElement.Testimonials.Select(x => new TestimonialItemModel(x as TestimonialItem)).ToList();
            
        }
    }
}
