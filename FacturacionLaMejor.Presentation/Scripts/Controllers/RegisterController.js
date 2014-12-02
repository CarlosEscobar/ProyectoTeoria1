'use strict';
angular.module('app.controllers')

    // Path: /Register
    .controller('RegisterCtrl', [
        '$scope', '$location', '$window', 'Login', function($scope, $location, $window, Login) {
            $scope.$root.title = 'AngularJS SPA | Register';
            // TODO: Register a New User

            $scope.RegisterMessage = false;

            $scope.login = function() {
                $location.path('/login');
                return false;
            };

            $scope.user = {

            };

            $scope.signup = function() {
                Login.signup($scope.user, function(response) {

                }, function(error) {

                });

                $scope.RegisterMessage = true;
            };

            $scope.$on('$viewContentLoaded', function() {
                $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
            });
        }
    ]);