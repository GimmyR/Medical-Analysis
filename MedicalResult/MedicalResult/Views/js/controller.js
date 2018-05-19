app.controller('ctrl-patients', ['$scope', 'service', function ($scope, service) {

	$scope.patients = [];

	var verifPatients = function(res){

		if(!res.error)
			$scope.patients = res.data;
		else
			alert(res.message);

	};

	var getPatients = function(){

		service.getPromise('GET', 'Patient', null, null)

		.then(function(res){

			verifPatients(res.data);

		}, function(err){ console.log(err); });

	};

	getPatients();

    $('.section-content').hide();
    $('.patients').fadeIn(300);

}]);