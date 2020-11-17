using System;
using AaronSadler.MegaNavV8.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace AaronSadler.MegaNavV8.Core.Extensions
{
    public static class MeganavV8ItemExtensions
    {
        public static string Url(this MeganavV8Item item, string culture = null, UrlMode mode = UrlMode.Default)
        {
            var umbracoContext = Umbraco.Web.Composing.Current.UmbracoContext;

            if (umbracoContext == null)
                throw new InvalidOperationException("Cannot resolve a Url when Current.UmbracoContext is null.");
            if (umbracoContext.UrlProvider == null)
                throw new InvalidOperationException(
                    "Cannot resolve a Url when Current.UmbracoContext.UrlProvider is null.");

            var contentItem = umbracoContext.Content.GetById(item.Udi);

            if (contentItem != null)
            {
                switch (contentItem.ContentType.ItemType)
                {
                    case PublishedItemType.Content:
                        return umbracoContext.UrlProvider.GetUrl(contentItem, mode, culture);

                    case PublishedItemType.Media:
                        return umbracoContext.UrlProvider.GetMediaUrl(contentItem, mode, culture,
                            Umbraco.Core.Constants.Conventions.Media.File);

                    default:
                        throw new NotSupportedException();
                }
            }

            return null;
        }
    }
}
