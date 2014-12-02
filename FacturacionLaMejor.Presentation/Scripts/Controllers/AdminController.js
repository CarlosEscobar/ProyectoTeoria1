'use strict';
angular.module('app.controllers')

    // Path: /admin
    .controller('AdminCtrl', [
        '$scope', '$location', '$window', 'Admin', function($scope, $location, $window, Admin) {
            $scope.$root.title = 'AngularJS SPA | Admin';

            // TODO: Admin

            $scope.isEditing = false;
            $scope.TodasLigas = [];

            $scope.loadLeagues = function() {
                Admin.loadLeagues(function(availableLeagues) {
                    $scope.TodasLigas = availableLeagues;
                }, function(error) {
                    alert('error loading available leagues');
                });
            };

            $scope.league = "";

            $scope.admin = function () {

                Admin.admin($scope.league, function (response) {
                    
                }, function (error) {

                });
                var leag;
                var leaguee = { Id: ($scope.TodasLigas[($scope.TodasLigas.length - 1)].Id + 1), Name: $scope.league.Name, Day: $scope.league.Day, Location: $scope.league.Location };
                leag = leaguee;
                $scope.TodasLigas.push(leag);
            };

            $scope.limpiar = function() {
                $scope.league.Name = "";
                $scope.league.Day = "";
                $scope.league.Location = "";
            };

            $scope.Dliga = "";

            $scope.deleteLeague = function (id) {

                var liga = { Id: id };
                $scope.Dliga = liga;

                Admin.deleteLeague($scope.Dliga, function (response) {

                }, function (error) {

                });

                for (var i = 0; i < $scope.TodasLigas.length; i++) {
                    if ($scope.TodasLigas[i].Id === id) {
                        $scope.TodasLigas.splice(i, 1);
                    }
                }
            };

            $scope.newleague = "";

            $scope.editLeague = function(id, teamname, fechaini, location) {
                $scope.isEditing = true;
                $scope.newleague.Id = id;
                $scope.newleague.Name = teamname;
                $scope.newleague.Day = fechaini;
                $scope.newleague.Location = location;
            };

            $scope.cancelEdit = function() {
                $scope.isEditing = false;
            };

            $scope.FinishEditing = function () {

                Admin.FinishEditing($scope.newleague, function (response) {

                }, function (error) {

                });

                for (var i = 0; i < $scope.TodasLigas.length; i++) {
                    if ($scope.TodasLigas[i].Id === $scope.newleague.Id) {
                        $scope.TodasLigas[i].Name = $scope.newleague.Name;
                        $scope.TodasLigas[i].Day = $scope.newleague.Day;
                        $scope.TodasLigas[i].Location = $scope.newleague.Location;
                    }
                }
                
            };

            $scope.FinishedEditing = function() {
                $scope.newleague.Name = "";
                $scope.newleague.Day = "";
                $scope.newleague.Location = "";
            };

        }
]);