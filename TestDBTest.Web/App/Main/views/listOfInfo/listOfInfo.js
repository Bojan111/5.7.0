(function () {
    angular.module('app').controller('app.views.listOfInfo.listOfInformation', [
        '$scope', '$uibModal', 'abp.services.app.list',
        function ($scope, $uibModal, listOfInformatioService) {
            var vm = this;


            vm.lists = [];

            function getLists() {
                listOfInformatioService.getAll({ skipCount: 0, maxResultCount: 999 }).then(function (result) {
                    debugger;
                    vm.lists = result.data.items;
                });
            }

            vm.openTaskCreationModal = function () {

                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/listOfInfo/createList.cshtml',
                    controller: 'app.views.listOfInfo.createList as vm',
                    backdrop: 'static',
                    windowClass: 'app-modal-window'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getLists();
                });
            };



            vm.openFormEditModal = function (list) {
                debugger;
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/listOfInfo/editList.cshtml',
                    controller: 'app.views.listOfInfo.editList as vm',
                    backdrop: 'static',
                    windowClass: 'app-modal-window',
                    resolve: {
                        list: function () {
                            return list;
                        }
                    }
                });

                modalInstance.result.then(function (list) {
                    var objIndex = myArray.findIndex((obj => obj.list.id == lists.id));

                    myArray[objIndex] = list;

                });
            }


            vm.delete = function (list) {

                listOfInformatioService.delete(list)
                    .then(function () {
                        abp.notify.info("Deleted List: ");
                        getLists();
                    });
            }
            getLists();

        }
    ]);
})();