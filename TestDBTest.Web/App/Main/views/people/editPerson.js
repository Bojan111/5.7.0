(function () {
    angular.module('app').controller('app.views.people.editPerson', [
        '$scope', '$uibModalInstance', 'abp.services.app.country', 'abp.services.app.person', 'person',
        function ($scope,  $uibModalInstance, countryService, personService, person) {
            var vm = this;
            debugger;

            vm.people = {  ...person  };


            vm.countries = [];

            countryService.getAllCountries().then(function (data) {
                vm.countries = data.data.countries;

            });


            vm.save = function () {
                abp.ui.setBusy();
                debugger;
                personService.updatePerson(vm.people)
                    .then(function (result) {
                        abp.notify.info(App.localize('SavedSuccessfully'));

                        $uibModalInstance.close(result.data);
                    }).finally(function () {
                        abp.ui.clearBusy();
                    });
            };


            //vm.save = function () {
            //    abp.ui.setBusy();
            //    personService.updatePerson(vm.people)
            //        .then(function (result) {
            //            abp.notify.info(App.localize('SavedSuccessfully'));

            //            $uibModalInstance.close(result.data);
            //        }).finally(function () {
            //            abp.ui.clearBusy();
            //        });
            //};

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

        }
    ]);
})();