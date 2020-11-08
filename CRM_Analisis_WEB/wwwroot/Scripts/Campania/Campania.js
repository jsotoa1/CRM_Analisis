function generarTabla() {
    $("#contTable").empty();
    mtGenerarTabla(arrayCampania, "tblCampania", "contTable", "titulosCampania", "valoresCampania");
    $('#tblCampania').DataTable();
    var arrayNotOrder = [5];
    mtRecuperarDatosTablaPersonalizada("/Campania/ObtenerCampania", null, "Account/Login", "tblCampania", "valoresCampania", arrayNotOrder);
}
function agregarCampania() {

    var nombre = $("#funcNombre").val();
    var porcentaje = $("#funcPorcentaje").val();
    var tipo_estado = document.getElementById("selectTipoEstado").value;
    var tipo_accion = document.getElementById("selectTipoAccion").value;

    if (nombre.length > 50 || porcentaje.length > 50) {

        if (nombre.length > 50) {
            swal("¡Error!", "El tamaño del texto de Nombre no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (porcentaje.length >50) {
            swal("¡Error!", "El campo Porcentaje no puede tener valores negativos", "warning");
            return false;
        } 

    }
    else {
        if (nombre === undefined || nombre === null || nombre === "") {
            swal("¡Error!", "Es necesario ingresar Nombre.", "warning");
            return false;
        } else {
            $.ajax({
                type: "POST",
                url: rootPath + '/Campania/GuardarCampania',
                data: {
                    Nombre: nombre, Porcetaje: porcentaje, Tipo_Estado: { Id: tipo_estado }, Tipo_Accion: { Id: tipo_accion }, 
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcNombre").val("");
                        $("#funcPorcentaje").val("");
                        $("#selectTipoEstado").val("").change();
                        $("#selectTipoAccion").val("").change();

                        $("#modalCrearCampania").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearCampania").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos de Campaña! ', 'warning');
                    $("#modalCrearCampania").modal('show');
                    return false;
                }
            });

        }
    }
}
function detalleModificarCampania(id) {
    if (id > 0) {
        $.ajax({
            type: "POST",
            url: rootPath + '/Campania/DetalleCampania?id=' + id,
            data: {

            },
            success: function (response) {
                if (response != null && response.success) {
                    $("#funcNombreEdit").val(response.Nombre);
                    $("#funcPorcentajeEdit").val(response.Porcetaje);
                    $("#selectTipoEstadoEdit").val(response.Tipo_Estado).change();
                    $("#selectTipoAccionEdit").val(response.Tipo_Accion).change();
                    $("#funcId").val(id);
                    $("#modalEditCampania").modal('show');
                    return true;
                }
                else {
                    msgBox(response.responseText, 'warning');
                    return false;
                }
            },
            error: function (response) {
                msgBox('Hubo un problema al consultar los datos de la Campaña. ', 'warning');
                return false;

            }
        });

    }
}
function guardarcambios() {
    var id = $("#funcId").val();
    var nombre = $("#funcNombreEdit").val();
    var porcentaje = $("#funcPorcentajeEdit").val();
    var tipo_estado = document.getElementById("selectTipoEstadoEdit").value;
    var tipo_accion = document.getElementById("selectTipoAccionEdit").value;

    if (nombre.length > 50 || porcentaje.length > 50) {

        if (nombre.length > 50) {
            swal("¡Error!", "El tamaño del texto de descripción no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (porcentaje.length > 50) {
            swal("¡Error!", "El campo precio no puede tener valores negativos", "warning");
            return false;
        }

    }
    else {
        if (nombre === undefined || nombre === null || nombre === "") {
            swal("¡Error!", "Es necesario ingresar el Nombre.", "warning");
            return false;
        } else {
            $.ajax({
                type: "POST",
                url: rootPath + '/Campania/ModificarCampania',
                data: {
                    Id: id, Nombre: nombre, Porcentaje: porcentaje, Tipo_Estado: { Id: tipo_estado }, Tipo_Accion: { Id: tipo_accion }, 
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcId").val("");
                        $("#funcNombreEdit").val("");
                        $("#funcPorcentajeEdit").val("");
                        $("#selectTipoEstadoEdit").val("").change();
                        $("#selectTipoAccionEdit").val("").change();

                        $("#modalCrearCampania").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearCampania").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos de Campaña. ', 'warning');
                    $("#modalCrearCampana").modal('show');
                    return false;
                }
            });

        }
    }
}
function EliminarCampania(id) {
    if (id > 0) {
        swal({
            title: '¿Confirmar eliminar?',
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
                    url: rootPath + '/Campania/EliminarCampania',
                    data: { id: id },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.Response) {
                            msgBox(data.Message, 'success');
                            generarTabla();
                            return true;
                        }
                        else {
                            msgBox(data.Message, 'warning');
                            return false;
                        }
                    },
                    error: function (error) {
                        msgBox('Hubo un problema al eliminar los datos.', 'warning');
                        return false;
                    }
                });
            }
        })

    } else {
        msgBox('Es necesario conocer los detalles del dato.', "error");
        return false;
    }
}

(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = $('.validarCampania');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                    form.classList.add('was-validated');
                }
                else {
                    event.preventDefault();
                    agregarCampania();
                    $("#formCrearCampania").removeClass("was-validated");
                    $("#modalCrearCampania").modal('hide');
                }
            }, false);
        });
    }, false);
})();

(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = $('.validarCampaniaUpdate');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                    form.classList.add('was-validated');

                }
                else {
                    event.preventDefault();
                    guardarcambios();
                    $("#formEditCampania").removeClass("was-validated");
                    $("#modalEditCampania").modal('hide');
                }
            }, false);
        });
    }, false);
})();