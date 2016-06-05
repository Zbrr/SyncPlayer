(function () {
    'use strict';

    angular
        .module('syncPlayer')
        .controller('headerController', headerController);

    headerController.$inject = ['$location'];

    function headerController($scope, $location, $http, limitToFilter) {

    }
})();
