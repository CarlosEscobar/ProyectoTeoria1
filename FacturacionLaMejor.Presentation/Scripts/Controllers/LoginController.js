'use strict';
angular.module('app.controllers')

    // Path: /login
    .controller('LoginCtrl', [
        '$scope', '$location', '$window', 'Login', function($scope, $location, $window, Login) {
            $scope.$root.title = 'AngularJS SPA | Sign In';
            // TODO: Authorize a user

            $scope.ShMessage1 = false;
            $scope.ShMessage2 = false;
            $scope.ShMessage3 = false;

            $scope.user = "";
            $scope.allUsers = [];

            $scope.loadUsers = function() {
                Login.loadUsers(function(users) {
                    $scope.allUsers = users;
                }, function(error) {
                    alert('Error loading users');
                });
            };

            $scope.existe = 1;
            var idpro;
            $scope.login = function(userName, password) {

                if (userName === "Admin"){
                    if(password !== "123") {
                        $scope.ShMessage1 = true;
                        $scope.ShMessage2 = false;
                        $scope.ShMessage3 = false;
                    } else {
                        $location.path('/admin');
                    }
                } else {

                    for (var i = 0; i < $scope.allUsers.length; i++) {
                        if ($scope.allUsers[i].Name === userName) {
                            if ($scope.allUsers[i].Password === password) {
                                $scope.existe = 2;
                                idpro = $scope.allUsers[i].Id;
                            } else {
                                $scope.existe = 3;
                            }
                        }
                    }

                    if ($scope.existe === 1) {
                        $scope.ShMessage1 = false;
                        $scope.ShMessage2 = true;
                        $scope.ShMessage3 = false;
                    } else if ($scope.existe === 2) {
                        var path = "/profile/";
                        path = path + idpro.toString();
                        $location.path(path);
                    } else if ($scope.existe === 3) {
                        $scope.ShMessage1 = false;
                        $scope.ShMessage2 = false;
                        $scope.ShMessage3 = true;
                    }
                }
                return false;
            };

            $scope.$on('$viewContentLoaded', function() {
                $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
            });
            $scope.register = function() {
                $location.path('/register');
                return false;
            };
        }
    ]);