﻿var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('TestDBTest');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);