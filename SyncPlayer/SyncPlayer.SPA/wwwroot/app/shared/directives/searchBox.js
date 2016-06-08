(function () {
    'use strict';

    appModule.directive('searchBox', searchBox);
    searchBox.$inject = ['$window', '$compile', '$rootScope'];

    function searchBox($window, $compile, $rootScope) {

        var getSongs = function () {
            return new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
                queryTokenizer: Bloodhound.tokenizers.whitespace,
                remote: {
                    url: '../Home/Search/?query=%QUERY',
                    wildcard: '%QUERY'
                }
            });
        }

        var initializeSearchBox = function (scope, element) {

            var playerTemplate = '<input class="typeahead" type="text" placeholder="Search...">';

            element.html(playerTemplate);
            $compile(element.contents())(scope);

            $(element).find(".typeahead").typeahead(null, {
                name: 'songs',
                display: 'Title',
                source: getSongs(),
                templates: {
                    suggestion: Handlebars.compile('<div>{{FileSource}} – {{Title}}</div>')
                }
            });

            $(element).find(".typeahead").bind('typeahead:select', function (ev, suggestion) {
                $rootScope.$broadcast('select-audio-file', suggestion);
            });
        };

        return {
            restrict: 'EA',
            link: function (scope, element, attrs) {
                initializeSearchBox(scope, element);
            }
        }
    }

})();