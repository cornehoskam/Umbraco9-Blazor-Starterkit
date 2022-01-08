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
    public class ChartElementModel : IElementModel
    {
        public string Title { get; set; }

        public ChartType ChartType { get; set; }

        public List<string> Labels { get; set; }

        public List<int> Values { get; set; }

        public bool IsValid { get; set; }

        public string UmbracoContentType => ChartElement.ModelTypeAlias;

        public ChartElementModel() { }

        public ChartElementModel(ChartElement chartElement)
        {
            Title = chartElement.Title;

            ChartType = chartElement.ChartType.ToLower() switch
            {
                "pie" => ChartType.Pie,
                "bar" => ChartType.Bar,
                _ => ChartType
            };

            Labels = chartElement.Labels.ToList();

            Values = new List<int>();
            foreach (var value in chartElement.Values)
            {
                if (int.TryParse(value, out var result))
                {
                    Values.Add(result);
                }
            }

            IsValid = Labels.Count == Values.Count;
        }
    }

    public enum ChartType
    {
        Pie,
        Bar
    }
}
