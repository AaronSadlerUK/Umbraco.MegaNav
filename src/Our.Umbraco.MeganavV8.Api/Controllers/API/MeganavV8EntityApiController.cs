using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;
using Constants = Our.Umbraco.MeganavV8.Core.Constants;

namespace Our.Umbraco.MeganavV8.Api.Controllers.API
{
    [PluginController(Constants.PackageName)]
    public class MeganavV8EntityApiController : UmbracoAuthorizedJsonController
    {
        public HttpResponseMessage GetById(string id)
        {
            var udiList = new List<Udi>();
            var udi = Udi.Parse(id);
            udiList.Add(udi);
            var entity = Services.ContentService.GetByIds(udiList).FirstOrDefault();

            if (entity != null)
            {
                string entityUrl = "#";

                if (entity.Published)
                {
                    var publishedEntity = Umbraco.Content(entity.Key);

                    if (publishedEntity != null)
                    {
                        entityUrl = publishedEntity.Url;
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
                    naviHide = entity.HasProperty("umbracoNaviHide") && entity.GetValue<bool>("umbracoNaviHide")
                });
            }

            return null;
        }
    }
}