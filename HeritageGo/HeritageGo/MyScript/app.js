
(function () {
    "use strict"
    var app = angular
        .module("fsmapp", ["aims.service", "ckeditor"])
        //.constant("appSettings", Settings)
        .config(['$compileProvider', function ($compileProvider) {
            $compileProvider.debugInfoEnabled(false);
        }])
        .filter('unsafe', function ($sce) {
            return function (val) {
                return $sce.trustAsHtml(val);
            }
        })

})();
