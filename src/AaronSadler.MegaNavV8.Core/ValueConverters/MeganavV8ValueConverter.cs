using System;
using System.Collections.Generic;
using System.Linq;
using AaronSadler.MegaNavV8.Core.Enums;
using AaronSadler.MegaNavV8.Core.Models;
using AaronSadler.MegaNavV8.Core.PropertyEditors;
using Newtonsoft.Json;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web;
using Umbraco.Web.PublishedCache;

namespace AaronSadler.MegaNavV8.Core.ValueConverters
{
    public class MeganavV8ValueConverter : PropertyValueConverterBase
    {
        private readonly IPublishedSnapshotAccessor _publishedSnapshotAccessor;
        private readonly ILogger _logger;

        private bool _removeNaviHideItems;

        public MeganavV8ValueConverter(IPublishedSnapshotAccessor publishedSnapshotAccessor, ILogger logger)
        {
            _publishedSnapshotAccessor = publishedSnapshotAccessor;
            _logger = logger;
        }

        public override bool IsConverter(IPublishedPropertyType propertyType)
        {
            return propertyType.EditorAlias.Equals(Constants.PropertyEditorAlias);
        }

        public override Type GetPropertyValueType(IPublishedPropertyType propertyType) => typeof(IEnumerable<MeganavV8Item>);

        public override object ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview)
        {
            if (inter == null)
            {
                return Enumerable.Empty<MeganavV8Item>();
            }

            var configuration = propertyType.DataType.ConfigurationAs<MeganavV8Configuration>();

            if (configuration != null)
            {
                _removeNaviHideItems = configuration.RemoveNaviHideItems;
            }

            try
            {
                var items = JsonConvert.DeserializeObject<IEnumerable<MeganavV8Item>>(inter.ToString());

                return BuildMenu(items);
            }
            catch (Exception ex)
            {
                _logger.Error<MeganavV8ValueConverter>("Failed to convert Meganav", ex);
            }

            return Enumerable.Empty<MeganavV8Item>();
        }

        private IEnumerable<MeganavV8Item> BuildMenu(IEnumerable<MeganavV8Item> items, int level = 0)
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
                        if (_removeNaviHideItems && !umbracoContent.IsVisible())
                        {
                            continue;
                        }

                        // set content to node
                        item.Content = umbracoContent;

                        // set title to node name if no override is set
                        if (string.IsNullOrWhiteSpace(item.Title))
                        {
                            item.Title = umbracoContent.Name(item.Culture);
                        }

                        if (!string.IsNullOrEmpty(item.Anchor))
                        {
                            item.Url = umbracoContent.Url(item.Culture) + $"{item.Anchor}";
                        }
                        else
                        {
                            item.Url = umbracoContent.Url(item.Culture);
                        }
                        // set url to most recent from published cache
                    }
                }

                // process child items
                if (item.Children.Any())
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