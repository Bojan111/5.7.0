(function () {
    angular.module('app').controller('app.views.forms.form', [
        '$scope', '$uibModal', 'abp.services.app.form',
        function ($scope, $uibModal, formService) {
            var vm = this;


            vm.forms = [];

            function getForms() {
                formService.getAll({ skipCount: 0, maxResultCount: 999 }).then(function (result) {
                    debugger;
                    vm.forms = result.data.items;
                });
            }           
           
            vm.openTaskCreationModal = function () {

                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/forms/createForm.cshtml',
                    controller: 'app.views.forms.createForm as vm',
                    backdrop: 'static',
                    windowClass: 'app-modal-window'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getForms();
                });
            };



            vm.openFormEditModal = function (form) {
                debugger;
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/forms/editForm.cshtml',
                    controller: 'app.views.forms.editForm as vm',
                    backdrop: 'static',
                    windowClass: 'app-modal-window',
                    resolve: {
                        form: function () {
                            return form;
                        }
                    }
                });

                modalInstance.result.then(function (form) {
                    var objIndex = myArray.findIndex((obj => obj.form.id == forms.id));

                    myArray[objIndex] = form;

                });
            }


            vm.delete = function (form) {

                formService.delete(form)
                    .then(function () {
                        abp.notify.info("Deleted person: " + form.personName);
                        getForms();
                    });
            }
            getForms();

        }
    ]);
})();