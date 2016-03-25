// Code goes here

(function () {

    var app = angular.module("studentWebsite", []);

    var MainController = function ($scope, StudentService) {

        var _Student = {

        };

        var _Choice = {

        };

        $scope.register = function () {
            console.log("REGISTER");
            var url = "http://localhost:18254/api/Account/Register";
            var username = ($scope.register.username);
            var email = ($scope.register.email);
            var password = ($scope.register.password);
            var confirmPass = ($scope.register.passwordConfirm);
            if(password == confirmPass){
                var data = {
                    UserName: username,
                    Email: email,
                    Password: password,
                    ConfirmPassword : confirmPass
                };
                $.ajax({
                    url: url,
                    type: 'POST',
                    contentType: 'application/json;charset=utf-8',
                    data: JSON.stringify(data)
                }).done(function (data) {
                    console.log(data);
                }).fail(function (err) { console.warn(err); });
            } else {
                $scope.error = "Passwords Dont Match";
                console.log("PASSWORD NO MATCH");
            }
        }

        $scope.logInUser = function () {
            var username = ($scope.login.username);
            var password = ($scope.login.password);
            var url = "http://localhost:18254/Token";

            var loginData = {
                grant_type: 'password',
                UserName: username,
                Password: password
            };

            $.ajax({
                type: 'POST',
                url: url,
                data: loginData
            }).done(function (data) {
                console.log("LOGGED IN");
                self.user(data.userName);
                // Cache the access token in session storage.
                sessionStorage.setItem(tokenKey, data.access_token);
            }).fail(function (err) { console.warn(err); });
        }

        /*
        var onGetAllComplete = function (data) {
            $scope.characters = data;
        };

        var onGetAllError = function (reason) {
            $scope.error = "Could not get all cartoon characters.";
        };

        $scope.search = function () {
            CartoonService.getAllCartoonCharacters()
              .then(onGetAllComplete, onGetAllError);
        };

        var onFindComplete = function (data) {
            $scope.person = data;
        };

        var onFindError = function (reason) {
            $scope.error = "Could not find a cartoon character.";
        };

        $scope.findCartoonCharacter = function (personId) {
            CartoonService.getCartoonCharacter(personId)
            .then(onFindComplete, onFindError);
        };

        var onAddComplete = function (data) {
            $scope.newPerson = data;

            _cartoonCharacter.FirstName = "";
            _cartoonCharacter.LastName = "";
            _cartoonCharacter.Gender = "";
            _cartoonCharacter.Occupation = "";

            _cartoonCharacter.Picture = "http://flintstones.zift.ca/images/Disney/";
        };

        var onAddError = function (reason) {
            $scope.error = "Could not add a cartoon character.";
        };

        $scope.addCartoonCharacter = function () {
            var data = {
                FirstName: $scope.cartoonCharacter.FirstName,
                LastName: $scope.cartoonCharacter.LastName,
                Gender: $scope.cartoonCharacter.Gender,
                Occupation: $scope.cartoonCharacter.Occupation,
                Picture: $scope.cartoonCharacter.Picture
            }
            CartoonService.addCartoonCharacter(data)
            .then(onAddComplete, onAddError);
        };

        var onDeleteComplete = function (data) {
            $scope.characters = data;
            $("#dialog_delete").dialog();
            $scope.PersonId = 0;
        };

        var onDeleteError = function (reason) {
            $scope.error = "Could not delete cartoon characters.";
        };

        $scope.deleteCartoonCharacter = function (personId) {
            CartoonService.deleteCartoonCharacter(personId)
            .then(onDeleteComplete, onDeleteError);
        };

        var onUpdateComplete = function (data) {
            $scope.person = undefined;
            $("#dialog_update").dialog();
        };

        var onUpdateError = function (reason) {
            $scope.error = "Could not delete cartoon characters.";
        };

        $scope.updateCartoonCharacter = function () {

            var data = {
                PersonId: $scope.person.PersonId,
                FirstName: $scope.person.FirstName,
                LastName: $scope.person.LastName,
                Gender: $scope.person.Gender,
                Occupation: $scope.person.Occupation,
                Picture: $scope.person.Picture
            }

            CartoonService.updateCartoonCharacter(data)
            .then(onUpdateComplete, onUpdateError);
        };

        $scope.PersonId = 0;
        $scope.message = "All Cartoon Characters";
        $scope.cartoonCharacter = _cartoonCharacter;
        */
    };

    app.controller("studentController", MainController);
}());