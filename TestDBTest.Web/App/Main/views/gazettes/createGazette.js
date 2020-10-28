(function () {
    angular.module('app').controller('app.views.gazettes.createGazette', [
        '$scope', '$uibModalInstance', 'abp.services.app.officialGazzete', 'abp.services.app.person', 'abp.services.app.country',
        function ($scope, $uibModalInstance, officialGazzete, personService, countryService) {
            var vm = this;

            vm.gazette = {};


            vm.countries = [];

            countryService.getAllCountries().then(function (data) {
                vm.countries = data.data.countries;

            });






            vm.persons = [];

            function getPerson() {

                personService.getAllPeople().then(function (result) {
                    debugger;
                    vm.persons = result.data.people;
                });
            }

            getPerson();

            var localize = abp.localization.getSource('TestDBTest');

            vm.saveTask = function () {
                //debugger;
                //vm.gazette.manufacturerInfos.push(vm.gazette.manufacturerInfosSingle)
                abp.ui.setBusy(
                    officialGazzete.customCreate(
                        vm.gazette
                    ).then(function (result) {
                        debugger;
                        abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage")));
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