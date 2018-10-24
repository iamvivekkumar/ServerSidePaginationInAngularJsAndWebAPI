var app = angular.module('employeeApp', ['ui.bootstrap']);

app.controller('employeeCtrl', function ($scope, $http) {

    $scope.maxSize = 5;     // Limit number for pagination display number.
    $scope.totalCount = 0;  // Total number of items in all pages. initialize as a zero
    $scope.pageIndex = 1;   // Current page number. First page is 1.-->
    $scope.pageSizeSelected = 5; // Maximum number of items per page.

    $scope.getEmployeeList = function () {
        $http.get("http://localhost:52859/api/Employee?pageIndex=" + $scope.pageIndex + "&pageSize=" + $scope.pageSizeSelected).then(
                       function (response) {
                           $scope.employees = response.data.employees;
                           $scope.totalCount = response.data.totalCount;
                       },
                       function (err) {
                           var error = err;
                       });
    }

    //Loading employees list on first time
    $scope.getEmployeeList();

    //This method is calling from pagination number
    $scope.pageChanged = function () {
        $scope.getEmployeeList();
    };

    //This method is calling from dropDown
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.getEmployeeList();
    };

});
