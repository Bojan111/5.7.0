(function () {
    angular.module('app').controller('app.views.forms.editForm', [
        '$scope', '$uibModalInstance', 'abp.services.app.form', 'abp.services.app.person','form',
        function ($scope, $uibModalInstance, formService, personService, form) {
            var vm = this;
            debugger;

            vm.forms = { ...form };


            vm.people = [];

            personService.getAllPeople().then(function (data) {
                vm.people = data.data.people;

            });


            vm.save = function () {
                abp.ui.setBusy();
                debugger;
                formService.update(vm.forms)
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