using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.Meganav.PropertyEditors
{
    public class MeganavConfiguration
    {
        [ConfigurationField("maxDepth", "Max Depth", "number", Description = "The maximum number of levels in the navigation")]
        public int MaxDepth { get; set; }

        [ConfigurationField("removeNaviHideItems", "Remove NaviHide Items", "boolean", Description = "Remove items where umbracoNaviHide is true")]
        public bool RemoveNaviHideItems { get; set; }
    }
}