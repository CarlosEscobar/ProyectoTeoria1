'use strict';
angular.module('app.controllers')

    // Path: /resetpassword
    .controller('ResetPasswordCtrl', [
        '$scope', '$location', '$window', 'Login', function ($scope, $location, $window, Login) {
            $scope.$root.title = 'AngularJS SPA | Reset Password';
            // TODO: Reset Password

            $scope.ResetMessage = false;

            $scope.user = {

            };

            $scope.resetpassword = function () {

                Login.resetpassword($scope.user, function (response) {

                }, function (error) {

                });

                $scope.ResetMessage = true;
            };

        }
    ]);