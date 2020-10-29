(function () {
    angular.module('app').controller('app.views.people.person', [
        '$scope', '$uibModal', 'abp.services.app.person',
        function ($scope, $uibModal, personService) {
            var vm = this;


            vm.people = [];

            
            function getAllPeople() {
                abp.ui.setBusy(
                    null,

                    personService.getAllPeople({

                    }).then(function (data) {
                        vm.people = data.data.people;
                    })
                );
            }


            vm.openTaskCreationModal = function () {
      
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/people/createPeople.cshtml',
                    controller: 'app.views.people.createPeople as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getAllPeople();
                });
            };

         

            vm.openPersonEditModal = function (person) {
                debugger;
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/people/editPerson.cshtml',
                    controller: 'app.views.people.editPerson as vm',
                    backdrop: 'static',
                    resolve: {
                        person: function () {
                            return person;
                        }
                    }
                });

                modalInstance.result.then(function (person) {
                    var objIndex = myArray.findIndex((obj => obj.person.id == persons.id));

                    myArray[objIndex] = person;

                });
            }


            vm.delete = function (person) {

                personService.deletePerson(person.id)
                    .then(function () {
                        abp.notify.info("Deleted person: " + person.name);
                        getAllPeople();
                    });
                //    }
                //});
            }


            getAllPeople();
        }
    ]);
})();