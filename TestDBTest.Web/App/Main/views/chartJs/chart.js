(function () {
	angular.module('app').controller('app.views.chartJs.chart', [
		'$scope', '$uibModal', 'abp.services.app.person',
		function ($scope, $uibModal, personService) {
			var vm = this;

			vm.people = [];



            function getAllPeople() {
                personService.getAllPeople({})
                    .then(function (response) {
						vm.people = response.data.people;
						var dates = vm.people.map(x => x.dateOfBirthFormatted)
						vm.dates = dates.filter((value, index) => dates.indexOf(value) === index);
						vm.sortedDates = [];
						for (var i = 0; i < vm.dates.length; i++) {
							var chartCount = {
								key: vm.dates[i],
								value: vm.people.filter(x => x.dateOfBirthFormatted == vm.dates[i]).length
							}
							vm.sortedDates.push(chartCount);
                        }

                        var countries = vm.people.map(x => x.assignedCountryCountry)
                        vm.countries = countries.filter((value, index) => countries.indexOf(value) === index);

                        vm.sortedCountries = [];
                        for (var i = 0; i < vm.countries.length; i++) {
                            var chartCount = {
                                key: vm.countries[i],
                                value: vm.people.filter(x => x.assignedCountryCountry == vm.countries[i]).length
                            }
                            vm.sortedCountries.push(chartCount);
                        }

                        vm.sortedKeys = [];

                        function getLength() {
                            if (vm.dates.length >= vm.countries.length) {
                                return vm.dates.length;
                            } else {
                                return vm.countries.length;
                            }
                        }

                        var arrayLength = getLength();

                        for (var i = 0; i < arrayLength; i++) {
                            vm.pair = [];

                            if (vm.dates[i] != null) {
                                vm.pair.push(vm.dates[i]);
                            }
                            if (vm.countries[i] != null) {
                                vm.pair.push(vm.countries[i]);
                            }
                           
                            vm.sortedKeys.push(vm.pair);
                        }

                        var ctx = document.getElementById('canvas').getContext('2d');
                        var myChart = new Chart(ctx, {
                            type: 'line',
                            data: {
                                labels: vm.sortedKeys,
                                datasets: [{
                                    label: 'Birth',
                                    data: vm.sortedDates.map(x => x.value),
           
                                    borderColor: [
                                        'rgb(54, 162, 235)'
                                    ],
                                    fill: false,
                                    borderWidth: 3
                                }, {
                                        label: 'Countries',
                                        data: vm.sortedCountries.map(x => x.value),
                                        
                                        borderColor: [
                                            'rgba(255, 99, 132, 1)',

                                        ],
                                        fill: false,
                                        borderWidth: 3
                                    }]
                            },
                            options: {
                                scales: {
                                    yAxes: [{
                                        display: true,
                                        scaleLabel: {
                                            display: true,
                                            labelString: 'value'
                                        },


                                    }],
                                    xAxes: [{
                                        display: true,
                                        scaleLabel: {
                                            display: true,
                                            labelString: 'key'
                                        },
                                        ticks: {
                                            fontSize: 20,
                                            fontColor: "black"
                                        }
                                    }],
                                }
                            }
                        });
                    });
            }

            getAllPeople();
        }   
    ]);
})();


