(function () {
    angular.module('app').controller('app.views.forms.createForm', [
        '$scope', '$uibModalInstance', 'abp.services.app.form', 'abp.services.app.person',
        function ($scope, $uibModalInstance, formService, personService) {
            var vm = this;
            debugger;
            vm.form = {};

            

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
                debugger;
                abp.ui.setBusy(
                    null,
                    formService.create(
                        vm.form
                    ).then(function () {
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