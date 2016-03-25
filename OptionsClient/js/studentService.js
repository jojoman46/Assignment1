// CartoonService.js

(function () {

    var StudentService = function ($http) {

        var baseUrl = 'http://localhost:18254/api/Choices';
        /*
        var _getCartoonCharacter = function (id) {
            return $http.get(baseUrl + id)
             .then(function (response) {
                 return response.data;
             });
        };

        var _getAllCartoonCharacters = function () {
            return $http.get(baseUrl)
              .then(function (response) {
                  return response.data;
              });
        };

        var _addCartoonCharacter = function (data) {
            return $http.post(baseUrl, data)
              .then(function (response) {
                  return response.data;
              });
        };

        var _deleteCartoonCharacter = function (id) {
            return $http.delete(baseUrl + id)
              .then(function (response) {
                  return response.data;
              });
        };

        var _updateCartoonCharacter = function (data) {
            return $http.put(baseUrl + data.PersonId, data)
              .then(function (response) {
                  return response.data;
              });
        };
        */

        var _register = function () {

        }
        return {
            /*
            getCartoonCharacter: _getCartoonCharacter,
            getAllCartoonCharacters: _getAllCartoonCharacters,
            addCartoonCharacter: _addCartoonCharacter,
            deleteCartoonCharacter: _deleteCartoonCharacter,
            updateCartoonCharacter: _updateCartoonCharacter
            */

            //register : _register
        };
    };

    var module = angular.module("studentWebsite");
    module.factory("StudentService", StudentService);

}());