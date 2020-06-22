using System.Collections.Generic;
using Newtonsoft.Json;
using Our.Umbraco.MeganavV8.Core.Enums;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;

namespace Our.Umbraco.MeganavV8.Core.Models
{
    public class MeganavV8Item
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Target { get; set; }

        public string Url { get; set; }
        public string QueryString { get; set; }

        [JsonIgnore]
        public IPublishedContent Content { get; set; }

        #region Internal

        public IEnumerable<MeganavV8Item> Children { get; set; }

        [JsonIgnore]
        public ItemType ItemType { get; set; }

        [JsonIgnore]
        public int Level { get; set; }
        public int Collapsed { get; set; }

        public GuidUdi Udi { get; set; }

        #endregion
    }
}