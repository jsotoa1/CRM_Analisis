function generarTabla() {
    $("#contTable").empty();
    mtGenerarTabla(arrayQueja, "tblQueja", "contTable", "titulosQueja", "valoresQueja");
    $('#tblQueja').DataTable();
    var arrayNotOrder = [7];
    mtRecuperarDatosTablaPersonalizada("/GestionQuejas/ObtenerQuejas", null, "Account/Login", "tblQueja", "valoresQueja", arrayNotOrder);
}
function agregarQueja() {

    var nombre = $("#funcNombre").val();
    var telefono = $("#funcTelefono").val();
    var email = $("#funcEmail").val();
    var nombrevendedor = $("#funcVendedor").val();
    var descripcion = $("#funcDescripcion").val();
    var fechaqueja = $("#funcFechaQueja").val();

    if (nombre.length > 50 || telefono.length > 8 || email.length > 50 || nombrevendedor.length > 50 || descripcion.length > 50 || fechaqueja.length > 50) {

        if (nombre.length > 50) {
            swal("¡Error!", "El tamaño del texto de descripción no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (telefono.length > 8) {
            swal("¡Error!", "El campo telefono solo valores numericos no mayor de 8 digitos", "warning");
            return false;
        } else if (email.length > 50) {
            swal("¡Error!", "El tamaño del texto de email no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (nombrevendedor.length > 50) {
            swal("¡Error!", "El campo Nombre Vendedor solo caracteres", "warning");
            return false;
        }
        else if (descripcion.length > 50) {
            swal("¡Error!", "El tamaño del texto de descripción no puede ser mayor a 50", "warning");
            return false;
        }
        else if (fechaqueja.length > 50) {
            swal("¡Error!", "El tamaño del texto de fecha queja no puede ser mayor a 50", "warning");
            return false;
        }

    }
    else {
        if (nombre === undefined || nombre === null || nombre === "") {
            swal("¡Error!", "Es necesario ingresar la descripción.", "warning");
            return false;
        } else {
            $.ajax({
                type: "POST",
                url: rootPath + '/GestionQuejas/GuardarQueja',
                data: {
                    Nombre: nombre, Telefono: telefono, Email: email, NombreVendedor: nombrevendedor, Descripcion: descripcion, FechaQueja: fechaqueja
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcNombre").val("");
                        $("#funcTelefono").val("");
                        $("#funcEmail").val("");
                        $("#funcVendedor").val("");
                        $("#funcDescripcion").val("");
                        $("#funcFechaQueja").val("");


                        $("#modalCrearQueja").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearQueja").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos de producto. ', 'warning');
                    $("#modalCrearQueja").modal('show');
                    return false;
                }
            });

        }
    }
}

function detalleModificarQueja(id) {
    if (id > 0) {
        $.ajax({
            type: "POST",
            url: rootPath + '/GestionQuejas/DetalleQueja?id=' + id,
            data: {

            },
            success: function (response) {
                if (response != null && response.success) {
                    $("#funcNombreEdit").val(response.Nombre);
                    $("#funcTelefonoEdit").val(response.Telefono);
                    $("#funcEmailEdit").val(response.email);
                    $("#funcVendedorEdit").val(response.nombrevendedor);
                    $("#funcDescripcionEdit").val(response.descripcion);
                    $("#funcFechaQuejaEdit").val(response.fechaqueja);
                    $("#funcId").val(id);
                    $("#modalEditQueja").modal('show');
                    return true;
                }
                else {
                    msgBox(response.responseText, 'warning');
                    return false;
                }
            },
            error: function (response) {
                msgBox('Hubo un problema al consultar los datos de la zona. ', 'warning');
                return false;

            }
        });

    }
}

function guardarcambios() {
    var nombre = $("#funcNombre").val();
    var telefono = $("#funcTelefono").val();
    var email = $("#funcEmail").val();
    var nombrevendedor = $("#funcVendedor").val();
    var descripcion = $("#funcDescripcion").val();
    var fechaqueja = $("#funcFechaQueja").val();

    if (nombre.length > 50 || telefono.length > 8 || email.length > 50 || nombrevendedor.length > 50 || descripcion.length > 50 || fechaqueja.length > 50) {

        if (nombre.length > 50) {
            swal("¡Error!", "El tamaño del texto de descripción no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (telefono.length > 8) {
            swal("¡Error!", "El campo telefono solo valores numericos no mayor de 8 digitos", "warning");
            return false;
        } else if (email.length > 50) {
            swal("¡Error!", "El tamaño del texto de email no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (nombrevendedor.length > 50) {
            swal("¡Error!", "El campo Nombre Vendedor solo caracteres", "warning");
            return false;
        }
        else if (descripcion.length > 50) {
            swal("¡Error!", "El tamaño del texto de descripción no puede ser mayor a 50", "warning");
            return false;
        }
        else if (fechaqueja.length > 50) {
            swal("¡Error!", "El tamaño del texto de fecha queja no puede ser mayor a 50", "warning");
            return false;
        }

    }
    else {
        if (nombre === undefined || nombre === null || nombre === "") {
            swal("¡Error!", "Es necesario ingresar el nombre.", "warning");
            return false;
        } else {
            $.ajax({
                type: "POST",
                url: rootPath + '/GestionQuejas/ModificarQueja',
                data: {
                    Id: id, Nombre: nombre, Telefono: telefono, Email: email, NombreVendedor: nombrevendedor, Descripcion: descripcion, FechaQueja: fechaqueja
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcNombreEdit").val(response.Nombre);
                        $("#funcTelefonoEdit").val(response.Telefono);
                        $("#funcEmailEdit").val(response.email);
                        $("#funcVendedorEdit").val(response.nombrevendedor);
                        $("#funcDescripcionEdit").val(response.descripcion);
                        $("#funcFechaQuejaEdit").val(response.fechaqueja);
                        $("#funcId").val(id);
                        $("#modalEditQueja").modal('show');

                        $("#modalCrearQueja").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearQueja").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos de Queja. ', 'warning');
                    $("#modalCrearQueja").modal('show');
                    return false;
                }
            });

        }
    }
}

function EliminarQueja(id) {
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
                    url: rootPath + '/GestionQuejas/EliminarQueja',
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
        var forms = $('.validarQueja');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                    form.classList.add('was-validated');
                }
                else {
                    event.preventDefault();
                    agregarQueja();
                    $("#formCrearQueja").removeClass("was-validated");
                    $("#modalCrearQueja").modal('hide');
                }
            }, false);
        });
    }, false);
})();

(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = $('.validarQuejaUpdate');
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
                    $("#formEditQueja").removeClass("was-validated");
                    $("#modalEditQueja").modal('hide');
                }
            }, false);
        });
    }, false);
})();