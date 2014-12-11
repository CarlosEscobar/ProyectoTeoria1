'use strict';
angular.module('app.controllers')

    // Path: /LaMayor
    .controller('LaMayorCtrl', [
        '$scope', '$location', '$window', 'Login', function ($scope, $location, $window, Login) {
            $scope.$root.title = 'AngularJS SPA | LaMayor';
            // TODO: La Mayor Home Page


            $scope.$on('$viewContentLoaded', function () {
                $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
            });
        }
    ]);