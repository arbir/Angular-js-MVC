
//1. create app module
var ItemApp = angular.module('myApp', ["ui.grid","ui.grid.pagination"]);

//5. create submitStudentForm() function. This will be called when user submits the form

 ItemApp.controller("validateCtrl", ['$scope', 'crudService',function ($scope, crudService) {
                ///  document.write("ffff");

     $scope.gridOptions = [];
     $scope.Code    = "";
     $scope.Name    = "";
     $scope.Qty     = "";
     $scope.Price   = "";
     $scope.Csgroup = "";



    $scope.submitItemForm = function () {
        //alert(JSON.stringify(data));
        var apiRoute = '/api/apItem/temp/';
        var data = {
            Code    :$scope.Code    ,
            Name    :$scope.Name    ,
            Qty     :$scope.Qty     ,
            Price   :$scope.Price   ,
            Csgroup :$scope.Csgroup 

        };
        var cmnparam = "[" + JSON.stringify(data) + "]";
        /////alert(cmnparam);
        var create = crudService.GetList(apiRoute,cmnparam);

     /*   var request = $http({
            method: "POST",
            url: apiRoute,
            data: cmnparam,
            dataType: "json"
        });
        */
        create.then(function (response) {
            alert(JSON.stringify(response));
           // $scope.Code = "yasin er gusti";
            
        },
        function (error) {
            console.log("error: " + error);
        }
        );

    };

    $scope.showList = function () {
        
        $scope.gridOptions = {

            paginationPageSizes: [25, 50, 75],

            paginationPageSize: 5,
          
            columnDefs: [

            { field: 'Csgroup' },

            { field: 'Code' },

            { field: 'Name' },

            { field: 'Qty' },

            { field: 'Price' },

             {
                 name: 'Action',
                 displayName: "Action",

                 enableColumnResizing: false,
                 enableFiltering: false,
                 enableSorting: false,
                 pinnedRight: true,


                 width: '15%',
                 headerCellClass: $scope.highlightFilteredHeader,
                 cellTemplate: '<span class="label label-info label-mini" style="text-align:center !important;">' +
                               '<a href="" title="Edit" ng-click="grid.appScope.Edit(row.entity)">' +
                                 '<i class="icon-edit" aria-hidden="true"></i> Edit' +
                               '</a>' +
                               '</span>' +

                               '<span class="label label-danger label-mini" style="text-align:center !important;">' +
                               '<a href="" title="Delete" ng-click="grid.appScope.delete(row.entity)">' +
                                 '<i class="icon-glyphicon glyphicon-trash" aria-hidden="true"></i> Delete' +
                               '</a>' +
                               '</span>'

             }
                

            ],

            onRegisterApi: function (gridApi) {

                $scope.grid1Api = gridApi;

            }

        };


        var apiRoute = '/api/apItem/GetAllData/';
        var receiveData = crudService.ShowData(apiRoute);
        receiveData.then(function (response) {
            console.log(response);
            $scope.gridOptions.data = response.data;
        },
         function (error) {
             console.log("error: " + error);
         }
        );

        

    };

    var receiveData;

    $scope.ShowList= function()
    {
        var apiRoute = '/api/apItem/GetAllData/';
        receiveData = crudService.ShowData(apiRoute);
        receiveData.then(function (response) {
            alert(JSON.stringify(response));

        },
         function (error) {
             console.log("error: " + error);
         }
        );
    }
    $scope.Edit=function(data)
    {
         alert(JSON.stringify(data));
        
        $scope.Csgroup = data.Csgroup;
        $scope.Code = data.Code;
        $scope.Name = data.Name;
        $scope.Qty = data.Qty;
        $scope.Price = data.Price;

    }

}]);




