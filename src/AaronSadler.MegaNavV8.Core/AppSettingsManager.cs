using System;
using System.Configuration;

namespace AaronSadler.MegaNavV8.Core
{
    public static class AppSettingsManager
    {
        public static bool GetDisableUmbracoCloudSync()
        {
            return ConfigurationManager.AppSettings["DisableUmbracoCloudSync"] != null 
                   && Convert.ToBoolean(ConfigurationManager.AppSettings["DisableUmbracoCloudSync"]);
        }

        public static bool GetDisableUmbracoCloudDependencySync()
        {
            return ConfigurationManager.AppSettings["DisableUmbracoCloudDependencySync"] != null
                   && Convert.ToBoolean(ConfigurationManager.AppSettings["DisableUmbracoCloudDependencySync"]);
        }
    }
}
