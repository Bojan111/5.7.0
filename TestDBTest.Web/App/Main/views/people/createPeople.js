(function () {
    angular.module('app').controller('app.views.people.createPeople', [
        '$scope', '$uibModalInstance', 'abp.services.app.country', 'abp.services.app.person',
        function ($scope, $uibModalInstance, countryService, personService) {
            var vm = this;


            debugger;
            vm.person = {
                name: '',
                assignedCountryId: null
            };
            var localize = abp.localization.getSource('TestDBTest');

            vm.countries = [];

            countryService.getAllCountries().then(function (data) {
                vm.countries = data.data.countries;

            });



            vm.saveTask = function () {
                abp.ui.setBusy(
                    null,
                    personService.createPerson(
                        vm.person
                    ).then(function () {
                        abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage"), vm.person.name));
                    
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