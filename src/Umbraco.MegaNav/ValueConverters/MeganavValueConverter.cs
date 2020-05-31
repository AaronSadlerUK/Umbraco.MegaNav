using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Our.Umbraco.Meganav.Enums;
using Our.Umbraco.Meganav.Models;
using Our.Umbraco.Meganav.PropertyEditors;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web;
using Umbraco.Web.PublishedCache;

namespace Our.Umbraco.Meganav.ValueConverters
{
    public class MeganavValueConverter : PropertyValueConverterBase
    {
        private readonly IPublishedSnapshotAccessor _publishedSnapshotAccessor;
        private readonly ILogger _logger;

        private bool RemoveNaviHideItems;

        public MeganavValueConverter(IPublishedSnapshotAccessor publishedSnapshotAccessor, ILogger logger)
        {
            _publishedSnapshotAccessor = publishedSnapshotAccessor;
            _logger = logger;
        }

        public override bool IsConverter(IPublishedPropertyType propertyType)
        {
            return propertyType.EditorAlias.Equals(Constants.PropertyEditorAlias);
        }

        public override Type GetPropertyValueType(IPublishedPropertyType propertyType) => typeof(IEnumerable<MeganavItem>);

        public override object ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview)
        {
            if (inter == null)
            {
                return Enumerable.Empty<MeganavItem>();
            }

            var configuration = propertyType.DataType.ConfigurationAs<MeganavConfiguration>();

            if (configuration != null)
            {
                RemoveNaviHideItems = configuration.RemoveNaviHideItems;
            }

            try
            {
                var items = JsonConvert.DeserializeObject<IEnumerable<MeganavItem>>(inter.ToString());

                return BuildMenu(items);
            }
            catch (Exception ex)
            {
                _logger.Error<MeganavValueConverter>("Failed to convert Meganav", ex);
            }

            return Enumerable.Empty<MeganavItem>();
        }

        internal IEnumerable<MeganavItem> BuildMenu(IEnumerable<MeganavItem> items, int level = 0)
        {
            items = items.ToList();

            foreach (var item in items)
            {
                item.Level = level;

                // it's likely a content item
                if (item.Id > 0)
                {
                    var umbracoContent = _publishedSnapshotAccessor.PublishedSnapshot.Content.GetById(item.Udi);

                    if (umbracoContent != null)
                    {
                        // set item type
                        item.ItemType = ItemType.Content;

                        // skip item if umbracoNaviHide enabled
                        if (RemoveNaviHideItems && !umbracoContent.IsVisible())
                        {
                            continue;
                        }

                        // set content to node
                        item.Content = umbracoContent;

                        // set title to node name if no override is set
                        if (string.IsNullOrWhiteSpace(item.Title) == true)
                        {
                            item.Title = umbracoContent.Name;
                        }
                    }
                }

                // process child items
                if (item.Children.Any() == true)
                {
                    var childLevel = item.Level + 1;

                    BuildMenu(item.Children, childLevel);
                }
            }

            // remove unpublished content items
            items = items.Where(x => x.Content != null || x.ItemType == ItemType.Link);

            return items;
        }
    }
}