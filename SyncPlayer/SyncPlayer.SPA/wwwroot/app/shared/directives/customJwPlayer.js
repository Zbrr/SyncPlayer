
(function () {
    'use strict';

    appModule.constant('jwplayer', jwplayer);
    appModule.directive('customJwPlayer', customJwPlayer);

    customJwPlayer.$inject = ['$window', '$compile', '$rootScope'];
    
    function customJwPlayer($window, $compile, $rootScope) {

        var player = (function () {
            
            var playerId;

            function init($scope, element) {
                buildJwPlayer($scope, element);
                registerEvents($scope);
            };

            function buildJwPlayer($scope, element) {
                playerId = $scope.playerId || "syncPlayer1";
                var playerTemplate = '<div id="' + playerId + '" class="jwplayer"></div>';
                element.html(playerTemplate);
                $compile(element.contents())($scope);
            };

            function registerEvents($scope) {
                $scope.$on('select-audio-file', selectAudioFile);
            };

            function selectAudioFile(event, audioFile) {
                jwplayer(playerId).setup({
                    "file": audioFile.Url
                });
                play();
            };

            function play() {
                jwplayer(playerId).play();
            };

            return {
                init: init
            }
        })();

        return {
            restrict: 'EA',
            scope: {
                playerId: "@"
            },
            link: function ($scope, element, attrs) {
                player.init($scope, element);
            }
        }
    }

})();