'use strict';
angular.module('app.controllers')

    // Path: /profile
    .controller('ProfileCtrl', [
        '$scope', '$location', '$window', '$stateParams', 'Admin', function($scope, $location, $window, $stateParams, Admin) {
            $scope.$root.title = 'Angular JSP | Mi perfil';
            // TODO: User Profile

            $scope.Ligas = [];
            $scope.myLigas = [];
            $scope.Users = [];
            $scope.AccountLeagues = [];
            $scope.user = "";
            $scope.league = "";

            $scope.loadLeaguesandUser = function () {

                Admin.loadLeagues(function (availableLeagues) {
                    $scope.Ligas = availableLeagues;
                }, function (error) {
                    alert('error loading available leagues');
                });

                Admin.loadallUsers(function(users) {
                    $scope.Users = users;
                }, function(error) {
                    alert('error loading users');
                });

                Admin.loadAL(function(accountligs) {
                    $scope.AccountLeagues = accountligs;
                }, function(error) {
                    alert('Error en la base de datos.');
                });

            };

            $scope.loadProfile = function() {
                for (var i = 0; i < $scope.Users.length; i++) {
                    if ($scope.Users[i].Id.toString() === $stateParams.id) {
                        $scope.userId = $stateParams.id;
                        $scope.userName = $scope.Users[i].Name;
                        $scope.userEmail = $scope.Users[i].Email;

                        var theuser = { Id: $stateParams.id, Name: $scope.Users[i].Name, Email: $scope.Users[i].Email, Password: $scope.Users[i].Password };
                        $scope.user = theuser;
                    }
                }

                
                for (var j = 0; j < $scope.AccountLeagues.length; j++) {
                    if ($scope.AccountLeagues[j].idAccount.toString() === $stateParams.id) {
                        var idl = $scope.AccountLeagues[j].idLeague;

                        for (var k = 0; k < $scope.Ligas.length; k++) {
                            if ($scope.Ligas[k].Id === idl) {
                                $scope.league = $scope.Ligas[k];
                            }
                        }

                        var p = $scope.league;
                        $scope.myLigas.push(p);
                    }
                }

                var left = [];

                for (var x = 0; x < $scope.Ligas.length; x++) {
                    var y = 0;

                    for (var z = 0; z < $scope.myLigas.length; z++) {
                        if ($scope.myLigas[z].Name === $scope.Ligas[x].Name) {
                            y++;
                        }
                    }

                    if (y == 0) {
                        left.push($scope.Ligas[x]);
                    }
                }

                $scope.Ligas = left;

            };

            $scope.SearchLeague = function() {
                for (var i = 0; i < $scope.Ligas.length; i++) {
                    if ($scope.Ligas[i].Name === $scope.Buscar) {
                        $location.path = ('/login');
                    }
                }
            };


            $scope.getLiga = function() {
                for (var i = 0; i < $scope.Ligas.length; i++) {
                    if ($scope.Ligas[i].Name === $scope.Buscar) {
                        return $scope.Ligas[i];
                    }
                }
                return null;
            };

            $scope.Register = function(idlig) {
                for (var i = 0; i < $scope.Ligas.length; i++) {
                    if ($scope.Ligas[i].Id === idlig) {
                        var l = $scope.Ligas[i];
                        $scope.league = $scope.Ligas[i];
                        $scope.myLigas.push(l);
                        $scope.Ligas.splice(i, 1);
                    }
                }

                var accleag = { idAccount: $scope.user.Id, idLeague: $scope.league.Id };
                $scope.acl = accleag;

                Admin.Register($scope.acl, function (response) {

                }, function (error) {

                });
            };


        }
    ]);