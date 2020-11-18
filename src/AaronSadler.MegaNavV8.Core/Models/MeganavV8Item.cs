using System;
using System.Collections.Generic;
using AaronSadler.MegaNavV8.Core.Enums;
using Newtonsoft.Json;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;

namespace AaronSadler.MegaNavV8.Core.Models
{
    public class MeganavV8Item
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Target { get; set; }

        public string Url { get; set; }
        public string Anchor { get; set; }

        [JsonIgnore]
        public IPublishedContent Content { get; set; }

        #region Internal

        public IEnumerable<MeganavV8Item> Children { get; set; }

        [JsonIgnore]
        public ItemType ItemType { get; set; }

        [JsonIgnore]
        public int Level { get; set; }
        public bool Collapsed { get; set; }

        public GuidUdi Udi { get; set; }
        public string Culture { get; set; }

        #endregion
    }
}