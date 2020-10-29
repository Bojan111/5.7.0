(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);


    //app.config([
    //    '$stateProvider', '$urlRouterProvider',
    //    function ($stateProvider, $urlRouterProvider) {
    //        $urlRouterProvider.otherwise('/');
    //        $stateProvider
    //            .state('tasklist', {
    //                url: '/',
    //                templateUrl: '/App/Main/views/task/list.cshtml',
    //                menu: 'TaskList' //Matches to name of 'TaskList' menu in SimpleTaskSystemNavigationProvider
    //            })
    //            .state('newtask', {
    //                url: '/new',
    //                templateUrl: '/App/Main/views/task/new.cshtml',
    //                menu: 'NewTask' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
    //            });
    //    }
    //]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');
            $qProvider.errorOnUnhandledRejections(false);

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in TestDBTestNavigationProvider
                    });
                $urlRouterProvider.otherwise('/users');
            }

            if (abp.auth.hasPermission('Pages.Roles')) {
                $stateProvider
                    .state('roles', {
                        url: '/roles',
                        templateUrl: '/App/Main/views/roles/index.cshtml',
                        menu: 'Roles' //Matches to name of 'Tenants' menu in TestDBTestNavigationProvider
                    });
                $urlRouterProvider.otherwise('/roles');
            }

        
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in TestDBTestNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in TestDBTestNavigationProvider
                });

            $stateProvider
                .state('list', {
                    url: '/list',
                    templateUrl: '/App/Main/views/task/list.cshtml',
                    menu: 'TaskList' //Matches to name of 'TaskList' menu in SimpleTaskSystemNavigationProvider
                })
                .state('new', {
                    url: '/new',
                    templateUrl: '/App/Main/views/task/new.cshtml',
                    menu: 'NewTask' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                })
                .state('country', {
                    url: '/country',
                    templateUrl: '/App/Main/views/countries/country.cshtml',
                    menu: 'CountryTask' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                });
            $stateProvider
                .state('person', {
                    url: '/person',
                    templateUrl: '/App/Main/views/people/person.cshtml',
                    menu: 'PeopleTask' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                })
                .state('listOfInfo', {
                    url: '/listOfInfo',
                    templateUrl: '/App/Main/views/listOfInfo/listOfInfo.cshtml',
                    menu: 'ListTask' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                });
            $stateProvider
                .state('form', {
                    url: '/form',
                    templateUrl: '/App/Main/views/forms/form.cshtml',
                    menu: 'FormTask' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                })
                .state('gazette', {
                    url: '/gazette',
                    templateUrl: '/App/Main/views/gazettes/gazette.cshtml',
                    menu: 'Gazette' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                })
                .state('chart', {
                    url: '/chart',
                    templateUrl: '/App/Main/views/chartJs/chart.cshtml',
                    menu: 'Chart' //Matches to name of 'Tenants' menu in TestDBTestNavigationProvider
                });
        }
    ]);

})();