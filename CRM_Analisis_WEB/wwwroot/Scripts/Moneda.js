function eliminarMoneda(id) {
    swal({
        title: '¿Confirmar baja?',
        text: '',
        type: 'question',
        showCancelButton: true,
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger',
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar',
        reverseButtons: this
    }).then((result) => {

        if (result.value) {

            $.ajax({
                type: "GET",
                url: rootPath + 'Moneda/EliminarMoneda?id=' + id,
                data: param = "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.Response) {
                        msgBox(data.Message + ".", 'success');
                        generarTabla();
                    }
                    else {
                        msgBox(data.Message, 'error');
                    }
                },
                error: function (error) {
                    msgBox('Hubo un problema al eliminar los datos datos.', 'error', 'Error');
                }
            })
        }
    })
}

function DardeBaja(id) {
    $.ajax({
        type: "GET",
        url: rootPath + 'Moneda/EstadoMoneda?id=' + id + '&estado=' + 0,
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.Response) {
                msgBox( data.Message + ".", 'success');
                generarTabla();
            }
            else {
                msgBox(data.Message , 'error');
            }
        },
        error: function (error) {
            msgBox('Hubo un problema al cambiar de estado el dato.', 'error', 'Error');
        }
    })
}

function DardeAlta(id) {
    $.ajax({
        type: "GET",
        url: rootPath + 'Moneda/EstadoMoneda?id=' + id + '&estado=' + 1,
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.Response) {
                msgBox(data.Message , 'success');
                generarTabla();
            }
            else {
                msgBox(data.Message + ".", 'error');
            }
        },
        error: function (error) {
            msgBox('Hubo un problema al eliminar los datos datos.', 'error', 'Error');
        }
    })
}


function agregar() {
    var descripcion = $("#inputDescripcion").val();
    var moneda = $("#inputMoneda").val();
    var ruta = rootPath + 'Moneda/CrearMoneda';
    if ((descripcion && descripcion.length < 100) && (moneda && moneda.length < 4)) {
        $.ajax({
            type: "POST",
            url: ruta,
            data: {
                ISO: moneda, Descripcion: descripcion
            },
            success: function (response) {
                if (response != null && response.success===true) {
                    msgBox("Registro agregado correctamente.", 'success');
                    $("#MyModal").modal("hide");
                    generarTabla();
                    $("#inputDescripcion").val("");
                    $("#inputMoneda").val("");
                } else if (response != null && !response.success) {
                    msgBox("Moneda ya registrada" + ", ISO ya registrada.", 'error');
                    $("#MyModal").modal("hide");
                    generarTabla();
                    $("#inputDescripcion").val("");
                    $("#inputMoneda").val("");
                }
                else {
                    msgBox(response.responseText + ".", 'error', 'Error');
                    $("#modalApertura").modal('show');
                }
            },
            error: function (response) {
                msgBox('Hubo un problema al guardar los datos de la apertura.', 'error', 'Error');
                $("#modalApertura").modal('show');
            }
        })
    }
    else {
        
    }

}


function modificar(id) {
    var descripcion = ""
    if (id > 0) {

        $.ajax({
            type: "POST",
            url: rootPath + 'Moneda/DetalleMoneda?id=' + id,
            data: {
                Id: id, Descripcion: descripcion
            },

            success: function (response) {
                console.log(response)
                if (response != null && response.success) {
                    $("#inputDescripcionMod").val(response.Descripcion);
                    $("#inputMonedaMod").val(response.ISO)
                    $("#txtid").val(id);
                    generarTablaAttrObj2(id, "General_Moneda");
                    $("#modalMonedaModificar").modal('show');
                }
                else {
                    msgBox(response.responseText + ".", 'error', 'Error');

                }
            },
            error: function (response) {
                msgBox('Hubo un problema al consultar los datos de la apertura.', 'error', 'Error');

            }
        })
    }
    else {
        msgBox("El id es un dato obligatorio.", "info")
    }
}

function guardarcambios() {
    var descripcion = $("#inputDescripcionMod").val();
    var id = $("#txtid").val();
    var moneda = $("#inputMonedaMod").val();
    if ((descripcion && descripcion.length < 100) && (moneda && moneda.length < 4)) {
        $.ajax({
            type: "POST",
            url: rootPath + 'Moneda/ModificarMoneda',
            data: {
                Id: id, Descripcion: descripcion, ISO: moneda
            },
            success: function (response) {
                if (response != null && response.success) {
                    msgBox("Registro modificado correctamente.", 'success');
                    generarTabla();
                    $("#inputDescripcionMod").val("");
                    $("#inputAbreviaturaMod").val("")
                    $("#txtid").val("");
                    $("#modalMonedaModificar").modal('hide');
                }
                else {
                    msgBox(response.responseText, 'error', 'Error');
                    $("#modalMonedaModificar").modal('show');
                }
            },
            error: function (response) {
                msgBox('Hubo un problema al guardar los cambios.', 'error', 'Error');
                $("#modalMonedaModificar").modal('show');
            }
        })
    }
    else {
        msgBox("La Descripción es un dato obligatorio.", "info")
    }
}