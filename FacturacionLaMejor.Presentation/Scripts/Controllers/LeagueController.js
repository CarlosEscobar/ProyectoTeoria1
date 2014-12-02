'use strict';
angular.module('app.controllers')

    // Path: /league/:id
    .controller('LeagueCtrl', [
        '$scope', '$location', '$window', '$rootScope', function($scope, $location, $window, $rootScope) {
            $scope.$root.title = 'Angular JSP | Liga';
            // TODO: League

            //  console.log($rootScope.rootligs[0].nombre);

            $scope.lospartidos = [
                { idjuego: 123, equipo1: 'Barcelona', equipo2: 'Real Madrid', s1: 0, s2: 0, fecha: new Date(), predicted: 0 },
                { idjuego: 34, equipo1: 'Juventus', equipo2: 'Milan', s1: 0, s2: 0, fecha: new Date(), predicted: 0 },
                { idjuego: 728, equipo1: 'Olimpia', equipo2: 'Real España', s1: 0, s2: 0, fecha: new Date(), predicted: 0 },
                { idjuego: 192, equipo1: 'Marathon', equipo2: 'Platense', s1: 0, s2: 0, fecha: new Date(), predicted: 0 },
                { idjuego: 436, equipo1: 'Corinthians', equipo2: 'Chivas', s1: 0, s2: 0, fecha: new Date(), predicted: 0 },
                { idjuego: 772, equipo1: 'Madrid FC', equipo2: 'Chelsea', s1: 0, s2: 0, fecha: new Date(), predicted: 0 }
            ];

            $scope.go = function(path) {
                $location.path(path);
            };

            $scope.isPredicting = false;

            $scope.Equipo1 = "";
            $scope.Score1 = "";
            $scope.Equipo2 = "";
            $scope.Score2 = "";

            $scope.StartPrediction = function(team1, team2) {
                $scope.isPredicting = true;
                $scope.Equipo1 = team1;
                $scope.Equipo2 = team2;
            };

            $scope.cancelPredict = function() {
                $scope.isPredicting = false;
            };

            $scope.Predict = function() {

                for (var i = 0; i < $scope.lospartidos.length; i++) {
                    if (($scope.lospartidos[i].equipo1 === $scope.Equipo1) && ($scope.lospartidos[i].equipo2 === $scope.Equipo2)) {
                        $scope.lospartidos[i].s1 = $scope.Score1;
                        $scope.lospartidos[i].s2 = $scope.Score2;
                        $scope.lospartidos[i].predicted = 1;
                    }
                }

                $scope.Score1 = "";
                $scope.Score2 = "";

                $scope.isPredicting = false;

            };

        }
    ]);