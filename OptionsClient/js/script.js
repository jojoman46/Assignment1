// Code goes here

(function () {

    var app = angular.module("studentWebsite", []);

    var MainController = function ($scope, StudentService) {

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
            console.log("LOG IN");
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
                //sessionStorage.setItem(tokenKey, data.access_token);
            }).fail(function (err) { console.warn(err); });
        }

        $scope.pickChoice = function () {
            console.log("CHOICE");

            var url = "http://localhost:18254/api/Choices";
            var yearTermId = ($("#idForYearTerm").val());
            var studentId = ($scope.option.studentId);
            var firstName = ($scope.option.firstName);
            var lastName = ($scope.option.lastName);
            var firstChoice = parseInt($("#firstOption").val());
            var secondChoice = parseInt($("#secondOption").val());
            var thirdChoice = parseInt($("#thirdOption").val());
            var fourthChoice = parseInt($("#fourthOption").val());

            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; 
            var yyyy = today.getFullYear();

            var hour = today.getHours();
            var min = today.getMinutes();
            var second = today.getSeconds();

            var timeStamp = "AM";

            if(hour >= 12){
                timeStamp = "PM";
            }

            var todayString = yyyy + "-" + mm + "-" + dd + " " + hour + ":" + min + ":" + second + " " + timeStamp; 

            var data = {
                YearTermId: yearTermId,
                StudentId: studentId,
                StudentFirstName: firstName,
                StudentLastName: lastName,
                FirstChoiceOptionId: firstChoice,
                SecondChoiceOptionId: secondChoice,
                ThirdChoiceOptionId: thirdChoice,
                FourthChoiceOptionId: fourthChoice,
                SelectionDate: todayString
            };
            
            $.ajax({
                type: 'POST',
                url: url,
                data: data
            }).done(function (data) {
                console.log("CHOICE COMPLETE");
                // Cache the access token in session storage.
                //sessionStorage.setItem(tokenKey, data.access_token);
            }).fail(function (err) { console.warn(err); });

        }

        $scope.populateOption = function () {
            $.ajax({
                url: "http://localhost:18254/api/Choices/registerJsonObject"
            }).done(function (data) {
                console.log("Seeding Data In Options");
                yearTerm = jQuery.parseJSON(data["curYearTerm"]);
                putYearTermId(yearTerm);
            });
        };

        function putYearTermId(yearTerm) {
            var YearTermString = yearTerm.Year + " ";
            if (yearTerm.Term == 10) {
                YearTermString += "Winter";
            } else if (yearTerm.Term == 20) {
                YearTermString += "Spring/Summer";
            } else {
                YearTermString += "Fall";
            }
            $("#optionYearTerm").val(YearTermString);
            $("#idForYearTerm").val(yearTerm.YearTermId);
        }

        function putOptionsList(validOptionsList) {
            console.log("putOptions");
            var arrayValidOptions = new Array();
            $.each(validOptionsList, function (index, element) {
                var option =  {
                    title: element.Title,
                    value: element.OptionId
                };
                arrayValidOptions.push(option);
            });
            $scope.firstOptionChoices = arrayValidOptions;
            $scope.secondOptionChoices = arrayValidOptions;
            $scope.thirdOptionChoices = arrayValidOptions;
            $scope.fourthOptionChoices = arrayValidOptions;
        }

        $.ajax({
            url: "http://localhost:18254/api/Choices/registerJsonObject"
        }).done(function (data) {
            validOptionsList = jQuery.parseJSON(data["validOptionsList"]);
            putOptionsList(validOptionsList);
        });

        /*
        $scope.regions = [
                {
                    name: "Alabama",
                    code: "AL"
                },
                {
                    name: "Alaska",
                    code: "AK"
                },
                {
                    name: "American Samoa",
                    code: "AS"
                }
        ];
        */


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