(function () {
    angular.module('app').controller('app.views.countries.country', [
        '$scope', '$uibModal', 'abp.services.app.country',
        function ($scope, $uibModal, countryService) {
            var vm = this;

            
            vm.countries = [];


            function getAllCountries() {
                abp.ui.setBusy( 
                    null,

                    countryService.getAllCountries({ 

                    }).then(function (data) {
                        vm.countries = data.data.countries;
                    })
                );
            }

            vm.openCountryCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/countries/createCountry.cshtml',
                    controller: 'app.views.countries.createCountry as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getAllCountries();
                });
            };


            vm.openCountryEditModal = function (country) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/countries/editCountry.cshtml',
                    controller: 'app.views.countries.editCountry as vm',
                    backdrop: 'static',
                    resolve: {
                        country: function () {
                            return country;
                        }
                    }
                });

                modalInstance.result.then(function (country) {
                    var objIndex = myArray.findIndex((obj => obj.country.id == country.id));

                    myArray[objIndex] = country;

                });
            }


            vm.delete = function (country) {
                countryService.deleteCountry(country.id)
                    .then(function () {
                        abp.notify.info("Deleted country: " + country.country);
                        getAllCountries();
                    });
            }



            getAllCountries();
        }
    ]);
})();