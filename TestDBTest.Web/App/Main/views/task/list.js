(function () {
    angular.module('app').controller('app.views.task.list', [
        '$scope', '$uibModal', 'abp.services.app.task',
        function ($scope, $uibModal, taskService) {
            var vm = this;

            vm.localize = abp.localization.getSource('TestDBTest');

            vm.tasks = [];

            $scope.selectedTaskState = 0;

            $scope.$watch('selectedTaskState', function (value) {
                vm.refreshTasks();
            });


            function getTasks() {
                abp.ui.setBusy( 
                    null,
                    taskService.getTasks({ 
                        state: $scope.selectedTaskState > 0 ? $scope.selectedTaskState : null
                    }).then(function (data) {
                        vm.tasks = data.data.tasks;
                    })
                );
            }

            vm.changeTaskState = function (task) {
                var newState;
                if (task.state == 1) {
                    newState = 2; //Completed
                } else {
                    newState = 1; //Active
                }

                taskService.updateTask({
                    taskId: task.id,
                    state: newState
                }).then(function () {
                    task.state = newState;
                    abp.notify.info(vm.localize('TaskUpdatedMessage'));
                });
            };

            vm.getTaskCountText = function () {
                return abp.utils.formatString(vm.localize('Xtasks'), vm.tasks.length);
            };



            vm.openTaskCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/task/new.cshtml',
                    controller: 'app.views.task.new as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getTasks();
                });
            };



            vm.delete = function (task) {
                countryService.deleteTask(task.id)
                    .then(function () {
                        abp.notify.info("Deleted country: " + task.description);
                        getTasks();
                    });
            }



            getTasks();
        }
    ]);
})();