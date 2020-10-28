(function () {
    angular.module('app').controller('app.views.countries.createCountry', [
        '$scope', '$uibModalInstance', 'abp.services.app.country',
        function ($scope, $uibModalInstance, countryService) {
            var vm = this;

            vm.countries = {
                country: '',
                city: ''
            };
          
            var localize = abp.localization.getSource('TestDBTest');

            vm.saveTask = function () {

                abp.ui.setBusy(
                    null,
                    countryService.createCountry(
                        vm.countries
                    ).then(function () {
                        abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage"), vm.countries.country));
                        $uibModalInstance.close();
                        //$location.path('/');
                    })
                );
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();