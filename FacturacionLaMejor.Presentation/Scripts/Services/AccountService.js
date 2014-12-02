'use strict';
angular.module('app.services')

    .factory('Login', function ($http) {
        return {
            forgotPassword: function (forgotPasswordModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/forgotpassword', forgotPasswordModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            signup: function (registerModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/signup', registerModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            resetpassword: function (resetModel, success, error) {
                $http
                    .post(
                        'http://localhost:1367/resetpassword', resetModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            loadUsers: function (success, error) {
                $http
                    .get(
                        'http://localhost:1367/loadUsers')
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }
        };
    });