var app = angular.module("myApp", ["ngRoute"]);
app.config(['$routeProvider', function ($routeProvider) 
    $routeProvider.when("/bina", { templateUrl: "bina.html", contoller: "myCtrl" });
app.controller('myCtrl', function ($scope, $http) {
    $scope.BinaNumarasi = "";
    $scope.OdaNumarasi = "";
    $scope.YatakSayisi = "";
    $scope.OdaId = "";
    $scope.BinaId = "";
    $scope.OdaListesi = [];
    $scope.Oda = [];
    $scope.b = false;


    $scope.Kaydet = function () {
        $scope.BinaNumarasi;
        $scope.YatakSayisi;
        $scope.OdaNumarasi;
    };

    $http({
        method: 'GET',
        url: './api/BinaList'
    }).then(function successCallback(response) {
        $scope.BinaListesi = response.data;
        $scope.BinaNumarasi = response.data.BinaNumarasi;
        console.log($scope.BinaListesi);
    }, function errorCallback(response) {
    });

    $http({
        method: 'GET',
        url: './api/AllOdaList'
    }).then(function successCallback(response) {
        $scope.OdaListesi = response.data;
        console.log(response);
    }, function errorCallback(response) {
    });

    $scope.ekle = function () {

        $scope.OdaListesi.push({ BinaNumarasi: $scope.BinaNumarasi, YatakSayisi: $scope.YatakSayisi, OdaNumarasi: $scope.OdaNumarasi });
        $scope.BinaListesi.push({ BinaId: $scope.BinaId, BinaNumarasi: $scope.BinaNumarasi });
        $scope.Oda.push({ BinaNumarasi: $scope.BinaNumarasi, YatakSayisi: $scope.YatakSayisi, OdaNumarasi: $scope.OdaNumarasi });

        $http({
            method: 'POST',
            url: './api/AddOda',
            data: { BinaId: $scope.BinaId, BinaNumarasi: $scope.BinaNumarasi, Yatak_Sayisi: $scope.YatakSayisi, OdaNumarasi: $scope.OdaNumarasi }
        });

    }

    $scope.ekle2 = function () {
        console.log($scope.YatakSayisi);
        $http({
            method: 'POST',
            url: './api/AddBina',
            data: { BinaId: $scope.BinaId, BinaNumarasi: $scope.BinaNumarasi, YatakSayisi: $scope.YatakSayisi, OdaNumarasi: $scope.OdaNumarasi }
        }).then(function timedRefresh(timeoutPeriod) {
            setTimeout("location.reload(true);", timeoutPeriod);
        });;
    }
    $scope.duzenle = function (row) {
        console.log(row);
        $scope.BinaId =row.BinaId.toString();
        $scope.BinaNumarasi = row.BinaNumarasi;
        $scope.OdaNumarasi = row.OdaNumarasi;
        $scope.YatakSayisi = row.YatakSayisi;
        $scope.b = true;
    }
    $scope.guncelle = function () {

        $http({
            method: 'POST',
            url: './api/UpdateBina',
            data: { BinaId: $scope.BinaId, BinaNumarasi: $scope.BinaNumarasi, YatakSayisi: $scope.YatakSayisi, OdaNumarasi: $scope.OdaNumarasi }
        }).then(function timedRefresh(timeoutPeriod) {
            setTimeout("location.reload(true);", timeoutPeriod);
        });
    }

    $scope.sil = function (value) {
        console.log(value);
        $http({
            method: 'POST',
            url: './api/DeleteBina?BinaId=' + value.BinaId,
        }).then(function timedRefresh(timeoutPeriod) {
            setTimeout("location.reload(true);", timeoutPeriod);
        });
    }
});