angular.module("umbraco.resources").factory("meganavV8Resource", function ($http, iconHelper) {
    return {
        getById: function (id, culture) {

<<<<<<< HEAD
            return $http.get("backoffice/MeganavV8/MeganavV8EntityApi/GetById?id=" + id + "&culture=" + (typeof culture === 'string' ? culture : culture.cultureName))
=======
            return $http.get("backoffice/MeganavV8/MeganavV8EntityApi/GetById?id=" + id + "&culture=" + culture)
>>>>>>> parent of c5615d1... Update meganavv8.resource.js - expected string, got object
                .then(function (response) {
                    var item = response.data;
                    item.icon = iconHelper.convertFromLegacyIcon(item.icon);
                    return response;
                }
            );
        }
    }
});