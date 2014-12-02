'use strict';
angular.module('app.controllers')

    // Path: /forgot-password
    .controller('ForgotPasswordCtrl', [
        '$scope', '$location', '$window', 'Login', function($scope, $location, $window, Login) {
            $scope.$root.title = 'AngularJS SPA | Recuperar Password';
            // TODO: Forgot Password

            $scope.ShowMessage = false;

            $scope.user = {

            };

            $scope.forgotPassword = function() {
                Login.forgotPassword($scope.user, function(response) {

                }, function(error) {

                });

                $scope.ShowMessage = true;
            };

        }
    ]);