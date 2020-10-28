(function () {
    angular.module('app').controller('app.views.gazettes.gazette', [
        '$scope', '$http', '$sce','$uibModal', 'abp.services.app.officialGazzete', 'abp.services.app.country',
        function ($scope, $http, $sce, $uibModal, officialGazzeteService, countryService) {
            var vm = this;

            console.log($http);
        
            vm.gazettes = [];

            function getgazettes() {
                officialGazzeteService.getAll({ skipCount: 0, maxResultCount: 999 }).then(function (result) {
           
                    vm.gazettes = result.data.items;
                });
            }


            function getCountries() {
                countryService.getAllCountries().then(function (result) {
                    vm.countries = result.data.countries;
                });
            }
            getCountries();

            vm.printPdf = function () {
                var url = "/PrintPdf/PrintPdf"

                var req = $http.post(url, vm.gazettes, {responseType: 'arraybuffer'})
                    .then(function (response) {
                        var file = new Blob([response.data], { type: 'application/pdf' });
                        var fileUrl = URL.createObjectURL(file);
                        window.open($sce.trustAsResourceUrl(fileUrl));
                    });

                abp.ui.setBusy(null, req);

            }

           
            vm.openTaskCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/gazettes/createGazette.cshtml',
                    controller: 'app.views.gazettes.createGazette as vm',
                    backdrop: 'static',
                    windowClass: 'app-modal-window'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getgazettes();
                });
            };


       
            vm.openGazetteEditModal = function (gazette) {
                debugger;
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/gazettes/editGazette.cshtml',
                    controller: 'app.views.gazettes.editGazette as vm',
                    backdrop: 'static',
                    windowClass: 'app-modal-window',
                    resolve: {
                        gazette: function () {
                            return gazette;
                        }
                    }
                });

                modalInstance.result.then(function (gazette) {
                    var objIndex = myArray.findIndex((obj => obj.gazette.id == gazette.id));

                    myArray[objIndex] = gazette;

                });
            }


            vm.delete = function (gazette) {

                officialGazzeteService.delete(gazette)
                    .then(function () {
                        abp.notify.info("Deleted person: " + gazette.applicationForUnwantedMedDevices);
                        getgazettes();
                    });
            }
            getgazettes();

        }
    ]);
})();