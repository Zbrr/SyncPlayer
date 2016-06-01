
(function () {
    'use strict';

    appModule.constant('jwplayer', jwplayer);
    appModule.directive('customJwPlayer', customJwPlayer);

    customJwPlayer.$inject = ['$window', '$compile', '$rootScope'];
    
    function customJwPlayer($window, $compile, $rootScope) {

        var getJwPlayerTemplate = function (playerId) {
            return '<div id="' + playerId + '" class="jwplayer"></div>';
        };

        var initializeJwPlayer = function (scope, element) {

            var playerId = scope.playerId || "syncPlayer1";
            var playerTemplate = getJwPlayerTemplate(playerId);

            element.html(playerTemplate);
            $compile(element.contents())(scope);

            jwplayer(playerId).setup({
                "file": "https://www.youtube.com/watch?v=1cQh1ccqu8M&list=PLmI03RN1Qwbd8rWq9ht2NHsVqxnP3hVgE&index=41"
            });

            jwplayer(playerId).play();
        };

        return {
            restrict: 'EA',
            scope: {
                playerId: "@"
            },
            link: function (scope, element, attrs) {
                initializeJwPlayer(scope, element);
            }
        }
    }

})();