
function Ajax(url, type, data, async) {
    var asincrono = false;
    var response = null;
    if (async !== undefined)
        asincrono = async != '' ? async : false;

    if (url != null || url != undefined || url != "" && type != null || type != undefined || type != "" && data != null || data != undefined || data != "") {
        $.ajax({
            url: url,
            data: data,
            type: type,
            async: asincrono,
            cache: false,
            success: function (result) {
                response = result;
            },
            error: function (error) {
                response = null;
            }
        });


    }
    else {
        response = null;
    }
    return response;
}


function notify(message, tipoMessage, tituloMessage) {
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
        html: message,
    });
}

function notifyResult(title, text, showCancelButton, confirmButtonClass, cancelButtonClass, confirmButtonText, cancelButtonText, callBackFuntion, reload) {
    if (title === null || title === undefined || title === '')
        title = ""
    if (text === null || text === undefined || text === '')
        text = "¿Esta seguro?";
    if (showCancelButton === null || showCancelButton === undefined || showCancelButton === '')
        showCancelButton = true;
    if (confirmButtonClass === null || confirmButtonClass === undefined || confirmButtonClass === '')
        confirmButtonClass = 'btn btn-success';
    if (cancelButtonClass === null || cancelButtonClass === undefined || cancelButtonClass === '')
        cancelButtonClass = 'btn btn-danger';
    if (confirmButtonText === null || confirmButtonText === undefined || confirmButtonText === '')
        confirmButtonText = 'Aceptar';
    if (cancelButtonText === null || cancelButtonText === undefined || cancelButtonText === '')
        cancelButtonText = 'Cancelar';

    if (reload === null || reload === undefined || reload === '')
        reload = false;

    var response = false;
    swal({
        title: title,
        text: text,
        type: 'question',
        showCancelButton: showCancelButton,
        confirmButtonClass: confirmButtonClass,
        cancelButtonClass: cancelButtonClass,
        confirmButtonText: confirmButtonText,
        cancelButtonText: cancelButtonText,
        reverseButtons: this,
    }).then((result) => {
        if (result.value) {
            if (callBackFuntion != undefined)
                setTimeout(function () {
                    var func = new Function(callBackFuntion)();
                }, 1000);
        }
        else {
            if (reload === true)
                window.location.reload();
        }
    });
}

