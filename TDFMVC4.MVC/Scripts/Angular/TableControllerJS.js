//Aqui es donde vamos a separar cada controlador por separado para administrarlo

angular.module('MyApp2',[])
       .controller('TableControllerJS', function ($scope, ContactService) //Inyectamos Contact Service
       {
           $scope.Contact = null;
           debugger
           ContactService.ListarPostsJson()
                  .then(function (d) {
                      debugger
                      $scope.Contact = d.data;
                  }, function () {
                      alert('No se encontraron registros');
                  });
       })
       .factory('ContactService', function ($http) //Creamos un Factory el cual es popular para configurar servicios
       {
           var fac = {};
           fac.ListarPostsJson = function ()
           {
               return $http.get('/Table/ListarPostsJson')  //La Direccion de donde va a leer los datos
           }
           return fac;
       });
