(function () {
    angular.module('app').controller('app.views.task.new', [
        '$scope', '$uibModalInstance', 'abp.services.app.task','abp.services.app.person',
        function ($scope, $uibModalInstance, taskService, personService) {
            var vm = this;

            vm.task = {
                description: '',
                assignedPersonId: null
            };
    
            var localize = abp.localization.getSource('TestDBTest');

            vm.people = []; 
           
            personService.getAllPeople().then(function (data) {
                vm.people = data.data.people;
             
            });
            
            vm.saveTask = function () {
                abp.ui.setBusy(
                    null,
                    taskService.createTask(
                        vm.task
                    ).then(function () {
                        abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage"), vm.task.description));
                        $uibModalInstance.close();
                    })
                );
            };
            debugger;
            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();