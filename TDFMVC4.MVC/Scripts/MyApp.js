(function () {
    //Creamos un Modulo
    var app = angular.module('MyApp', ['ngRoute']); //va a utilizar ['ng-Route'] cuando implemente el routing

    //Creamos un Controller
    app.controller
                  ('HomeTwoController', function ($scope) { // $scope se utiliza para compartir datos de la vista al controller
                      $scope.Message = "OK"
                  });
}
)();


