using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Media;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Infrastructure.Media;
using Umbraco.Extensions;
using Umbraco9.Core.UmbracoModels;

namespace Umbraco9.Core.Models.Miscellaneous
{
    public class TestimonialItemModel
    {
        public string FullName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FunctionOrTitle { get; set; }
        public string Testimonial { get; set; }

        public TestimonialItemModel() { }

        public TestimonialItemModel(TestimonialItem testimonialItem)
        {
            FullName = testimonialItem.Fullname;
            FunctionOrTitle = testimonialItem.FunctionOrTitle;
            Testimonial = testimonialItem.Testimonial;
            ProfilePictureUrl = testimonialItem.ProfilePicture.LocalCrops.Src + testimonialItem.ProfilePicture.LocalCrops.GetCropUrl("profilePicture", new ImageSharpImageUrlGenerator(new Configuration()));
        }
    }
}
