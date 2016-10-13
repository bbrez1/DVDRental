// INFINITE MOVIES
angular.module('infiniteScroll', ['masonryLayout', 'infinite-scroll'])
    .controller("infiniteScroll", function ($scope, $http, $location) {

        var pageCounter = 0;
        var busy = false;
        var wasLastEmpty = false;
        var lastElementsNum = 2;
        $scope.items = [];
        $scope.selectedItems = [];

        $scope.what = "0";
        $scope.types = "";

        $scope.selectMovie = function (item) {
            item.ObjectId = item.id;
            $scope.selectedItems.push(item);
            
        }

        $scope.removeMovie = function (item) {
            $scope.selectedItems.splice($scope.selectedItems.indexOf(item), 1);
        }

        $scope.postMovies = function (userId) {
            

            console.log($scope.selectedItems);

            return $http.post('/api/Rent/', { Movies: $scope.selectedItems, Id: userId }).
              then(function (response) {

                  alert("Movies Successfully Rented");
                  $scope.selectedItems = [];

                  return response.data;
              }, function (response) {
                  // called asynchronously if an error occurs
                  // or server returns response with an error status.
              });
        };

        $scope.loadMore = function () {
            if (busy || wasLastEmpty) return;

            busy = true;

            var url = "/api/Movie/" + pageCounter;
            $http.get(url).success(function (data) {
                for (var i = 0; i < data.length; i++) {
                    $scope.items.push(data[i]);
                }

                if ($scope.items.length == 0) {
                    wasLastEmpty = true;
                }

                pageCounter++;
                busy = false;
                
            }.bind(this));
        };

        $scope.loadMore();

    });





angular.module('customerModule', [])
    .controller("customerController", function ($scope, $http, $location) {

        var busy = false;
        var wasLastEmpty = false;
        $scope.items = [];

        $scope.loadMore = function () {
            if (busy || wasLastEmpty) return;

            busy = true;

            var url = "/api/Customer/";
            $http.get(url).success(function (data) {
                for (var i = 0; i < data.length; i++) {
                    $scope.items.push(data[i]);
                }

                if ($scope.items.length == 0) {
                    wasLastEmpty = true;
                }

                pageCounter++;
                busy = false;

            }.bind(this));
        };

        $scope.loadMore();

    });



angular.module("myApp", [ /* module dependancies */
                "infiniteScroll", "customerModule"]);