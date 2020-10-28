(function () {
    angular.module('app').controller('app.views.countries.editCountry', [
        '$scope', '$uibModalInstance', 'abp.services.app.country', 'country',
        function ($scope, $uibModalInstance, countryService, country) {
            var vm = this;

            vm.cou = { ...country };

            vm.save = function () {
                abp.ui.setBusy();
                
                countryService.updateCountry(vm.cou)
                    .then(function (result) {
                        abp.notify.info(App.localize('SavedSuccessfully'));

                        $uibModalInstance.close(result.data);
                    }).finally(function () {
                        abp.ui.clearBusy();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

        }
    ]);
})();