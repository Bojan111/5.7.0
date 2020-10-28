(function () {
    angular.module('app').controller('app.views.gazettes.editGazette', [
        '$scope', '$uibModalInstance', 'abp.services.app.officialGazzete', 'abp.services.app.person', 'gazette',
        function ($scope, $uibModalInstance, officialGazzete, personService, gazette) {
            var vm = this;
            debugger;

            //vm.gazette = { ...gazette };


            vm.gazette = {
                officialGazzete: gazette,
                medicalDeviceInfo: gazette.medicalDeviceInfoSingle,
                useOfMedicalDevices: gazette.useOfMedicalDevicesSingle,
                manufacturerInfo: gazette.manufacturerInfosSingle
            };


            vm.persons = [];

            function getPerson() {

                personService.getAllPeople().then(function (result) {
                    vm.persons = result.data.people;
                });
            }

            getPerson();

            vm.saveTask = function () {
                abp.ui.setBusy();
                debugger;
                officialGazzete.customUpdate(vm.gazette)
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