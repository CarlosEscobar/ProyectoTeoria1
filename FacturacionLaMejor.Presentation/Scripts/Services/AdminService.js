'use strict';
angular.module('app.services')

    .factory('Admin', function ($http) {
        return {
            admin: function (adminModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/admin', adminModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            FinishEditing: function (adminModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/FinishEditing', adminModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            deleteLeague: function (adminModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/deleteLeague', adminModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            Register: function(AccountLeagueModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/Register', AccountLeagueModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            addNewTeam: function(TeamModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/addNewTeam', TeamModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            deleteTeam: function(TeamModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/deleteTeam', TeamModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            FinishEditing1: function(TeamModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/FinishEditing1', TeamModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            addNewMatch: function(MatchModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/addNewMatch', MatchModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            deleteGame: function(MatchModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/deleteGame', MatchModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            FinishEditing2: function(MatchModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/FinishEditing2', MatchModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            addLT: function(LeagueTeamModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/addLT', LeagueTeamModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            addLM: function(LeagueMatchModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/addLM', LeagueMatchModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            loadLeagues: function (success, error) {
                $http
                    .get(
                        'http://localhost:1367/leagues/available')
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            loadallUsers: function (success, error) {
                $http
                    .get(
                        'http://localhost:1367/loadallUsers')
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            loadTeams: function (success, error) {
                $http
                    .get(
                        'http://localhost:1367/loadTeams')
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            loadMatches: function (success, error) {
                $http
                    .get(
                        'http://localhost:1367/loadMatches')
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            loadAL: function (success, error) {
                $http
                    .get(
                        'http://localhost:1367/loadAL')
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            loadLT: function (success, error) {
                $http
                    .get(
                        'http://localhost:1367/loadLT')
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            loadLM: function (success, error) {
                $http
                    .get(
                        'http://localhost:1367/loadLM')
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }
        };
    });