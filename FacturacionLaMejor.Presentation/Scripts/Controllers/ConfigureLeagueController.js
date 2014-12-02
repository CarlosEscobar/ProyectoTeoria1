'use strict';
angular.module('app.controllers')

    // Path: /ConfigureLeague
    .controller('ConfigLeagueCtrl', [
        '$scope', '$location', '$window', '$stateParams', 'Admin', function($scope, $location, $window, $stateParams, Admin) {
            $scope.$root.title = 'AngularJS SPA | ConfigLeague';

            // TODO: Configure a League

            $scope.Equipos = [];
            $scope.Partidos = [];
            $scope.myEquipos = [];
            $scope.myPartidos = [];
            $scope.Leagues = [];
            $scope.LeagueTeams = [];
            $scope.LeagueMatches = [];
            $scope.theleag = "";
            $scope.team = "";
            $scope.newTeam = "";
            $scope.match = "";
            $scope.newMatch = "";
            $scope.nnLT = "";
            $scope.nnLM = "";
            $scope.isEditing1 = false;
            $scope.isEditing2 = false;

            $scope.LoadLeague = function () {

                Admin.loadLeagues(function(availableLeagues) {
                    $scope.Leagues = availableLeagues;
                }, function(error) {
                    alert('error loading available leagues');
                });
                
                Admin.loadTeams(function(theteams) {
                    $scope.Equipos = theteams;
                }, function(error) {
                    alert('error loading teams');
                });

                Admin.loadMatches(function(thematches) {
                    $scope.Partidos = thematches;
                }, function(error) {
                    alert('error loading matches');
                });

                Admin.loadLT(function (leagteams) {
                    $scope.LeagueTeams = leagteams;
                }, function (error) {
                    alert('error loading matches');
                });

                Admin.loadLM(function (leagmatches) {
                    $scope.LeagueMatches = leagmatches;
                }, function (error) {
                    alert('error loading matches');
                });


            };

            $scope.loadL = function() {
                for (var i = 0; i < $scope.Leagues.length; i++) {
                    if ($scope.Leagues[i].Id.toString() === $stateParams.id) {
                        var ll = $scope.Leagues[i];
                        $scope.theleag = ll;
                        $scope.lId = $scope.theleag.Name;
                    }
                }

                for (var j = 0; j < $scope.LeagueTeams.length; j++) {
                    if ($scope.LeagueTeams[j].idLeague.toString() === $stateParams.id) {
                        var idtea = $scope.LeagueTeams[j].idTeam;

                        for (var jj = 0; jj < $scope.Equipos.length; jj++) {
                            if ($scope.Equipos[jj].Id === idtea) {
                                var tea = $scope.Equipos[jj];
                                $scope.myEquipos.push(tea);
                            }
                        }
                   }
                }

                for (var k = 0; k < $scope.LeagueMatches.length; k++) {
                    if ($scope.LeagueMatches[k].idLeague.toString() === $stateParams.id) {
                        var idmat = $scope.LeagueMatches[k].idMatch;

                        for (var kk = 0; kk < $scope.Partidos.length; kk++) {
                            if ($scope.Partidos[kk].Id === idmat) {
                                var mat = $scope.Partidos[kk];
                                $scope.myPartidos.push(mat);
                            }
                        }
                    }
                }

            };

            $scope.addNewTeam = function () {

                Admin.addNewTeam($scope.team, function (response) {

                }, function (error) {

                });

                var nLT = { idLeague: $stateParams.id, idTeam: ($scope.myEquipos[($scope.myEquipos.length - 1)].Id + 1) };
                var tteam;
                var tt = { Id: ($scope.myEquipos[($scope.myEquipos.length - 1)].Id + 1), Name: $scope.team.Name, NumberOfPlayers: $scope.team.NumberOfPlayers, Coach: $scope.team.Coach };
                tteam = tt;
                $scope.myEquipos.push(tteam);


                $scope.nnLT = nLT;

                Admin.addLT($scope.nnLT, function (response) {

                }, function (error) {

                });
            };

            $scope.cleanTeam =  function() {
                $scope.team.Name = "";
                $scope.team.NumberOfPlayers = "";
                $scope.team.Coach = "";
            }

            $scope.dTeam = "";
            $scope.deleteTeam = function (idt) {

                var t = { Id: idt };
                $scope.dTeam = t;

                Admin.deleteTeam($scope.dTeam, function (response) {

                }, function (error) {

                });

                for (var i = 0; i < $scope.myEquipos.length; i++) {
                    if ($scope.myEquipos[i].Id === idt) {
                        $scope.myEquipos.splice(i, 1);
                    }
                }
            };

            $scope.editTeam = function(nid, teamname, numplayers, coach) {
                $scope.isEditing1 = true;
                $scope.newTeam.Id = nid;
                $scope.newTeam.Name = teamname;
                $scope.newTeam.NumberOfPlayers = numplayers;
                $scope.newTeam.Coach = coach;
            };

            $scope.cancelEdit1 = function() {
                $scope.isEditing1 = false;
            };

            $scope.FinishEditing1 = function() {
                
                Admin.FinishEditing1($scope.newTeam, function (response) {

                }, function (error) {

                });

                for (var i = 0; i < $scope.Equipos.length; i++) {
                    if ($scope.Equipos[i].Id === $scope.newTeam.Id) {
                        $scope.Equipos[i].Name = $scope.newTeam.Name;
                        $scope.Equipos[i].NumberOfPlayers = $scope.newTeam.NumberOfPlayers;
                        $scope.Equipos[i].Coach = $scope.newTeam.Coach;
                    }
                }
            };

            $scope.FinishedEditing1 = function() {
                $scope.newTeam.Name = "";
                $scope.newTeam.NumberOfPlayers = "";
                $scope.newTeam.Coach = "";
            }; 

            $scope.addNewGame = function () {
                
                Admin.addNewMatch($scope.match, function (response) {

                }, function (error) {

                });


                var nLM = { idLeague: $stateParams.id, idMatch: ($scope.myPartidos[($scope.myPartidos.length - 1)].Id + 1) };
                var ng;
                var ngame = { Id: ($scope.myPartidos[($scope.myPartidos.length - 1)].Id + 1), Team1: $scope.match.Team1, Team2: $scope.match.Team2, Day: $scope.match.Day }
                ng = ngame;
                $scope.myPartidos.push(ng);

                $scope.nnLM = nLM;

                Admin.addLM($scope.nnLM, function (response) {

                }, function (error) {

                });

            };

            $scope.cleanMatch = function() {
                $scope.match.Team1 = "";
                $scope.match.Team2 = "";
                $scope.match.Day = "";
            };

            $scope.dGame = "";
            $scope.deleteGame = function (id) {

                var t = { Id: id };
                $scope.dGame = t;

                Admin.deleteGame($scope.dGame, function (response) {

                }, function (error) {

                });

                for (var i = 0; i < $scope.Partidos.length; i++) {
                    if ($scope.Partidos[i].Id === id) {
                        $scope.Partidos.splice(i, 1);
                    }
                }
            };

            $scope.editGame = function(idgame, team1, team2, day) {
                $scope.isEditing2 = true;
                $scope.newMatch.Id = idgame;
                $scope.newMatch.Team1 = team1;
                $scope.newMatch.Team2 = team2;
                $scope.newMatch.Day = day;
            };

            $scope.cancelEdit2 = function() {
                $scope.isEditing2 = false;
            };

            $scope.FinishEditing2 = function () {

                Admin.FinishEditing2($scope.newMatch, function (response) {

                }, function (error) {

                });

                for (var i = 0; i < $scope.Partidos.length; i++) {
                    if ($scope.Partidos[i].Id === $scope.newMatch.Id) {
                        $scope.Partidos[i].Team1 = $scope.newMatch.Team1;
                        $scope.Partidos[i].Team2 = $scope.newMatch.Team2;
                        $scope.Partidos[i].Day = $scope.newMatch.Day;
                    }
                }
            };

            $scope.FinishedEditing2 = function() {
                $scope.newMatch.Team1 = "";
                $scope.newMatch.Team2 = "";
                $scope.newMatch.Day = "";
            };

    }
    ]);