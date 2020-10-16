function localizar(elemento, direccion) {

	var geocoder = new google.maps.Geocoder();

	var map = new google.maps.Map(document.getElementById(elemento), {
		zoom: 16,
		scrollwheel: true,
		mapTypeId: google.maps.MapTypeId.ROADMAP
	});

	geocoder.geocode({ 'address': direccion }, function (results, status) {
		if (status === 'OK') {
			var resultados = results[0].geometry.location,
				resultados_lat = resultados.lat(),
				resultados_long = resultados.lng();

			console.log("Latitud " + resultados_lat);
			console.log("Longitud " + resultados_long);

			//
			$("#itemMapa").val(status);
			$("#itemCoordenadas").val(resultados_lat + ", " + resultados_long);

			res = $("#itemCoordenadas").val();

			//msgBox("res: " + res, 'info');
			//

			map.setCenter(results[0].geometry.location);
			var marker = new google.maps.Marker({
				map: map,
				position: results[0].geometry.location
			});
		} else {
			var mensajeError = "";
			if (status === "ZERO_RESULTS") {
				mensajeError = "No hubo resultados para la dirección seleccionada.";
			} else if (status === "OVER_QUERY_LIMIT" || status === "REQUEST_DENIED" || status === "UNKNOWN_ERROR") {
				mensajeError = "Error general del mapa.";
			} else if (status === "INVALID_REQUEST") {
				mensajeError = "Error de la web. Contacte con Departamento IT.";
			}

			msgBox(mensajeError, 'info');
			document.querySelector("#" + elemento).innerHTML = "";

		}
	});


}
