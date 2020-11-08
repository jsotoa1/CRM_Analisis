function generarTabla() {
    $("#contTable").empty();
    mtGenerarTabla(arrayCliente, "tblCliente", "contTable", "titulosCliente", "valoresCliente");
    $('#tblCliente').DataTable();
    var arrayNotOrder = [10];
    mtRecuperarDatosTablaPersonalizada("/Clientes/ObtenerClientes", null, "Account/Login", "tblCliente", "valoresCliente", arrayNotOrder);
}
function agregarCliente() {

    var nombre = $("#funcNombre").val();
    var razonsocial = $("#funcRazonSocial").val();
    var nit = $("#funcNIT").val();
    var direccion = $("#funcDireccion").val();
    var pbx = $("#funcPBX").val();
    var fax = $("#funcFAX").val();
    var email = $("#funcEmail").val();
    var paginaweb = $("#funcPaginaWeb").val();
    var descripcion = $("#funcDescripcion").val();
    var tipoCliente = document.getElementById("selectTipoCliente").value;

    if (nombre.length > 50 || razonsocial.length > 50 || nit.length > 11 || direccion.length > 50 || pbx.length > 15 || fax.length > 15 || email.length > 50 || descripcion.length > 50) {

        if (nombre.length > 50) {
            swal("¡Error!", "El tamaño del texto de nombre no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (razonsocial.length > 50) {
            swal("¡Error!", "El tamaño del texto de razon social no puede ser mayor a 50.", "warning");
            return false;
        } else if (nit.length > 11) {
            swal("¡Error!", "El tamaño del texto de NIT no puede ser mayor a 50", "warning");
            return false;
        }
        else if (direccion.length > 50) {
            swal("¡Error!", "El tamaño del texto de Dirección no puede ser mayor a 50", "warning");
            return false;
        } else if (pbx.length > 15) {
            swal("¡Error!", "El tamaño del texto de PBX no puede ser mayor a 15", "warning");
            return false;
        } else if (fax.length > 15) {
            swal("¡Error!", "El tamaño del texto de FAX no puede ser mayor a 15", "warning");
            return false;
        } else if (email.length > 50) {
            swal("¡Error!", "El tamaño del texto de Email no puede ser mayor a 50", "warning");
            return false;
        }
        else if (descripcion.length > 50) {
            swal("¡Error!", "El tamaño del texto de Descripcion no puede ser mayor a 50", "warning");
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
                url: rootPath + '/Cliente/GuardarCliente',
                data: {
                    Nombre: nombre, RazonSocial: razonsocial, NIT: nit, Direccion: direccion, PBX: pbx, FAX: fax, Email: email, PaginaWeb: paginaweb, Descripcion: descripcion, TipoCliente: { Id: tipoCliente },
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcNombre").val("");
                        $("#funcRazonSocial").val("");
                        $("#funcNIT").val("");
                        $("#funcDireccion").val("");
                        $("#funcPBX").val("");
                        $("#funcFAX").val("");
                        $("#funcEmail").val("");
                        $("#funcPaginaWeb").val("");
                        $("#funcDescripcion").val("");
                        $("#selectTipoCliente").val("").change();

                        $("#modalCrearCliente").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearCliente").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos del Cliente. ', 'warning');
                    $("#modalCrearCliente").modal('show');
                    return false;
                }
            });

        }
    }
}
function detalleModificarCliente(id) {
    if (id > 0) {
        $.ajax({
            type: "POST",
            url: rootPath + '/Clientes/DetalleCliente?id=' + id,
            data: {

            },
            success: function (response) {
                if (response != null && response.success) {
                    $("#funcNombre").val(response.Nombre);
                    $("#funcRazonSocial").val(response.RazonSocial);
                    $("#funcNIT").val(response.NIT);
                    $("#funcDireccion").val(response.Direccion);
                    $("#funcPBX").val(response.PBX);
                    $("#funcFAX").val(response.FAX);
                    $("#funcEmail").val(response.Email);
                    $("#funcPaginaWeb").val(response.PaginaWeb);
                    $("#funcDescripcion").val(response.Descripcion);
                    $("#selectTipoCliente").val(response.TipoCliente).change();
                    $("#funcId").val(id);
                    $("#modalEditCliente").modal('show');
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
    var id = $("#funcId").val();
    var nombre = $("#funcNombre").val();
    var razonsocial = $("#funcRazonSocial").val();
    var nit = $("#funcNIT").val();
    var direccion = $("#funcDireccion").val();
    var pbx = $("#funcPBX").val();
    var fax = $("#funcFAX").val();
    var email = $("#funcEmail").val();
    var paginaweb = $("#funcPaginaWeb").val();
    var descripcion = $("#funcDescripcion").val();
    var tipoCliente = document.getElementById("selectTipoCliente").value;

    if (nombre.length > 50 || razonsocial.length > 50 || nit.length > 11 || direccion.length > 50 || pbx.length > 15 || fax.length > 15 || email.length > 50 || descripcion.length > 50) {

        if (nombre.length > 50) {
            swal("¡Error!", "El tamaño del texto de nombre no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (razonsocial.length > 50) {
            swal("¡Error!", "El tamaño del texto de razon social no puede ser mayor a 50.", "warning");
            return false;
        } else if (nit.length > 11) {
            swal("¡Error!", "El tamaño del texto de NIT no puede ser mayor a 50", "warning");
            return false;
        }
        else if (direccion.length > 50) {
            swal("¡Error!", "El tamaño del texto de Dirección no puede ser mayor a 50", "warning");
            return false;
        } else if (pbx.length > 15) {
            swal("¡Error!", "El tamaño del texto de PBX no puede ser mayor a 15", "warning");
            return false;
        } else if (fax.length > 15) {
            swal("¡Error!", "El tamaño del texto de FAX no puede ser mayor a 15", "warning");
            return false;
        } else if (email.length > 50) {
            swal("¡Error!", "El tamaño del texto de Email no puede ser mayor a 50", "warning");
            return false;
        }
        else if (descripcion.length > 50) {
            swal("¡Error!", "El tamaño del texto de Descripcion no puede ser mayor a 50", "warning");
            return false;

        }
    }
    else {
        if (nombre === undefined || nombre === null || nombre === "") {
            swal("¡Error!", "Es necesario ingresar la nombre.", "warning");
            return false;
        } else {
            $.ajax({
                type: "POST",
                url: rootPath + '/Clientes/ModificarCliente',
                data: {
                    Id: id, Nombre: nombre, RazonSocial: razonsocial, NIT: nit, Direccion: direccion, PBX: pbx, FAX: fax, Email: email, PaginaWeb: paginaweb, Descripcion: descripcion, TipoCliente: { Id: tipoCliente },
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcId").val("");
                        $("#funcNombre").val("");
                        $("#funcRazonSocial").val("");
                        $("#funcNIT").val("");
                        $("#funcDireccion").val("");
                        $("#funcPBX").val("");
                        $("#funcFAX").val("");
                        $("#funcEmail").val("");
                        $("#funcPaginaWeb").val("");
                        $("#funcDescripcion").val("");
                        $("#selectTipoCliente").val("").change();

                        $("#modalCrearCliente").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearCliente").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos del Cliente. ', 'warning');
                    $("#modalCrearCliente").modal('show');
                    return false;
                }
            });

        }
    }
}

(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = $('.validarCliente');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                    form.classList.add('was-validated');
                }
                else {
                    event.preventDefault();
                    agregarProducto();
                    $("#formCrearCliente").removeClass("was-validated");
                    $("#modalCrearCliente").modal('hide');
                }
            }, false);
        });
    }, false);
})();


(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = $('.validarClienteUpdate');
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
                    $("#formEditCliente").removeClass("was-validated");
                    $("#modalEditCliente").modal('hide');
                }
            }, false);
        });
    }, false);
})();