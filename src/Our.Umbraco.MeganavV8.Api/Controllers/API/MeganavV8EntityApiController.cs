using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;
using Constants = Our.Umbraco.MeganavV8.Core.Constants;

namespace Our.Umbraco.MeganavV8.Api.Controllers.API
{
    [PluginController(Constants.PackageName)]
    public class MeganavV8EntityApiController : UmbracoAuthorizedJsonController
    {
        private readonly IVariationContextAccessor _variationContextAccessor;

        public MeganavV8EntityApiController(IVariationContextAccessor variationContextAccessor)
        {
            _variationContextAccessor = variationContextAccessor;
        }
        public HttpResponseMessage GetById(string id, string url, string culture = null)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                _variationContextAccessor.VariationContext = new VariationContext(culture);
            }
            var udiList = new List<Udi>();
            var udi = Udi.Parse(id);
            udiList.Add(udi);
            var entity = Services.ContentService.GetByIds(udiList).FirstOrDefault();

            if (entity != null)
            {
                string entityUrl = "#";
                string entityCulture = null;

                if (entity.Published)
                {
                    var publishedEntity = Umbraco.Content(entity.Key);

                    if (publishedEntity != null)
                    {
                        entityUrl = publishedEntity.Url;
                        cculture
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    id = entity.Id,
                    udi = entity.GetUdi(),
                    name = entity.Name,
                    icon = entity.ContentType.Icon,
                    url = entityUrl,
                    published = entity.Published,
                    naviHide = entity.HasProperty("umbracoNaviHide") && entity.GetValue<bool>("umbracoNaviHide"),
                    culture = cculture
                });
            }

            return null;
        }
    }
}