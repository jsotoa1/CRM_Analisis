function msgBox(message, tipoMessage, tituloMessage) {
    if (tituloMessage == null) {
        tituloMessage = message;
        message = '';
    }

    swal({
        title: tituloMessage,
        text: message,
        type: tipoMessage,
        confirmButtonClass: 'btn btn-success',
        confirmButtonText: 'Aceptar',
    });
}