(function () {
    angular.module('app').controller('app.views.listOfInfo.createList', [
        '$scope', '$uibModalInstance', 'abp.services.app.listOfInformation',
        function ($scope, $uibModalInstance, listOfInformationService) {
            var vm = this;

            vm.lists = {};

            var localize = abp.localization.getSource('TestDBTest');

            vm.saveTask = function () {

                abp.ui.setBusy(
                    null,
                    listOfInformationService.create(
                        vm.lists
                    ).then(function () {
                        abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage")));
                        $uibModalInstance.close();
                    })
                );
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();