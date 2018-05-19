var app = angular.module('app', ['route']);

var route = angular.module('route', ['ngRoute']);

route.config(['$routeProvider', function($routeProvider){

	$routeProvider
		.when('/patients', {
			templateUrl: 'Views/templates/patients.html',
			controller: 'ctrl-patients'
		})

		.otherwise({
			redirectTo: '/patients'
		});

}]);