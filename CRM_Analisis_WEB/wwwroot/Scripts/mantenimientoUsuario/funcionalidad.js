
function mostrarFuncionalidad() {
    var table = $('#tblFuncionalidad').DataTable();
    var estado = "";
    var botonEstado = "";
    table.destroy();
    //$("#wait-dialog").modal("show");
    $.ajax({
        url: rootPath + '/MantRolFuncionalidad/ObtenerFuncionalidades',
        type: "POST",
        data: {},
        success: function (data) {
            var sessionActiva = -1;
            try {
                sessionActiva = data.indexOf("Login?ReturnUrl");
            } catch (e) {
                sessionActiva = -1;
            }
            if (sessionActiva == -1) {

                if (data[0].Message != null) {
                    msgBox(data[0].Message, 'error');
                }
                else {
                    $('#valoresFuncion').empty();
                    data.forEach(function (obj) {
                        if (obj.Estado == 1) {
                            estado = "Activo";
                            botonEstado = '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Desactivar" onclick="cambiarEstado(' + obj.Id + ', 1)"><i class="fa fa-toggle-on"></i></button> ';
                        }
                        else {
                            estado = "No Activo";
                            botonEstado = '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Activar" onclick="cambiarEstado(' + obj.Id + ', 0)"><i class="fa fa-toggle-off"></i></button> ';
                        }
                        if (obj.Url == null) { obj.Url = "" }
                        if (obj.Observaciones == null) { obj.Observaciones = "" }
                        if (obj.Imagen == null) { obj.Imagen = "" }
                        if (obj.FuncionalidadHijo == null) { obj.FuncionalidadHijo = "" }

                        $("#valorFunc" + obj.Id).remove();
                        $('#valoresFuncion').append('<tr id="valorFunc' + obj.Id + '">' +
                            '<td>' + obj.Id + '</td>' +
                            '<td>' + obj.Descripcion + '</td>' +
                            '<td>' + obj.NombreMenu + '</td>' +
                            '<td>' + obj.Url+ '</td>' +
                            '<td><i class="' + obj.Imagen + '"></i></button></td>' +
                            '<td>' + obj.Observaciones + '</td>' +
                            '<td>' + obj.FuncionalidadHijo  + '</td>' +
                            '<td id="idEstadoFunc' + obj.id + '">' + estado + '</td>' +
                            '<td>' +
                            '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Editar" onclick="modificarRegistroFunc(' + obj.Id + ',\'' + obj.Descripcion + '\',\'' + obj.Url + '\',\'' + obj.Imagen + '\',\'' + obj.Observaciones + '\',\'' + obj.IdFuncionalidad + '\',\'' + obj.NombreMenu + '\')"><i class="fa fa-edit"></i></button> ' +
                            botonEstado +
                            '<button class="btn btn-danger" data-toggle="tooltip" data-placement="bottom" title="Eliminar" onclick="EliminarRegistroFuncionalidad(' + obj.Id + ',true)"><i class="fa fa-trash-o"></i></button> ' +
                            '</td>' +
                            '</tr>');
                    });
                    $('#tblFuncionalidad').DataTable();
                    //$(function () {
                    //    $('[data-toggle="tooltip"]').tooltip()
                    //})
                }
            }
            else {
                window.location.replace(rootPath + "Account/Login?ReturnUrl=%MantRolFuncionalidad%2fmantRolUsuarioFunc");
            }
        },
        error: function (error) {
            console.log("Error al obtener datos de la url: " + rootPath + "MantRolFuncionalidad/ObtenerFuncionalidades");
            msgBox('Hubo un problema al consultar datos.', 'warning');
        }
    });

    $("#funcDescripcion").val('');
    $("#funcNombreMenu").val('');
    $("#funcUrl").val('');
    $("#funcImagen").val('');
    $("#funcObservaciones").val('');
}

function crearFuncionalidad() {
    $("#wait-dialog").modal("show");
    $("#dvAttrObj").hide();
    if (idFuncionalidad != 0) {

        idFuncionalidad = 0;
        $("#funcDescripcion").val('');
        $("#funcNombreMenu").val('');
        $("#funcUrl").val('');
        $("#funcImagen").val('');
        $("#funcObservaciones").val('');
    }

    $.ajax({
        url: rootPath + '/MantRolFuncionalidad/recuperarFuncionalidad',
        type: "POST",
        data: {},
        success: function (data) {
            var sessionActiva = -1;
            try {
                sessionActiva = data.indexOf("Login?ReturnUrl");
            } catch (e) {
                sessionActiva = -1;
            }
            if (sessionActiva == -1) {
                $("#wait-dialog").modal("hide");
                if (data[0].Message != null) {
                    msgBox(data[0].Message, 'error');
                }
                else {
                    $("#opcFunc0").remove();
                    $('#listFuncionalidades').append('<option id="opcFunc0" value="0">Sin Funcionalidad padre</option>');
                    data.forEach(function (obj) {
                        $("#opcFunc" + obj.Id).remove();
                        $('#listFuncionalidades').append('<option id="opcFunc' + obj.Id + '" value="' + obj.Id + '">' + obj.Descripcion + '</option>');
                    });
                }
            }
            else {
                window.location.replace(rootPath + "Account/Login?ReturnUrl=%MantRolFuncionalidad%2fmantRolUsuarioFunc");
            }

        },
        error: function (error) {
            $("#wait-dialog").modal("hide");
            console.log("Error al obtener datos de la url: " + rootPath + "MantRolFuncionalidad/recuperarFuncionalidad");
            msgBox('Hubo un problema al consultar datos de roles.', 'warning', 'Error');
        }
    });
    //$('#funcDescripcion').focus();
    setTimeout(function () { $('input[name="funcDescripcion"]').focus() }, 600);
}
function guardarFuncionalidad() {
    if (idFuncionalidad != 0) {
        guardarCambiosFuncionalidad();
    }
    else {
        guardarNuevaFuncionalidad();
    }
}

function guardarNuevaFuncionalidad() {
    var descripcion = $("#funcDescripcion").val();
    var url = $("#funcUrl").val();
    var imagen = $("#funcImagen").val();
    var observaciones = $("#funcObservaciones").val();
    var idFuncionalidadHijo = $("#listFuncionalidades").val();
    var nombreMenu = $("#funcNombreMenu").val();

    if (idFuncionalidadHijo == "" || idFuncionalidadHijo == null) {
        idFuncionalidadHijo = 0
    }
    //$('#modalFuncionalidad').modal('hide');
    $.ajax({
        url: rootPath + '/MantRolFuncionalidad/guardarFuncionalidad',
        type: "POST",
        data: { Descripcion: descripcion, Url: url, Imagen: imagen, Observaciones: observaciones, IdFuncionalidad: idFuncionalidadHijo, NombreMenu: nombreMenu },
        success: function (data) {
            var sessionActiva = -1;
            try {
                sessionActiva = data.indexOf("Login?ReturnUrl");
            } catch (e) {
                sessionActiva = -1;
            }
            if (sessionActiva == -1) {
                if (data.Response) {
                    msgBox('Registro guardado exitosamente.', 'success');
                    mostrarFuncionalidad();
                    $('#modalFuncionalidad').modal('hide');
                }
                else {
                    if (data.Message != "" && data.Message != null && data.Message != 'undefined') {
                        msgBox(data.Message, 'info');
                    }
                    else {
                        msgBox('Registro no guardado.', 'warning');
                    }
                }
            }
            else {
                window.location.replace(rootPath + "Account/Login?ReturnUrl=%MantRolFuncionalidad%2fmantRolUsuarioFunc");
            }
            $("#wait-dialog").modal("hide");
        },
        error: function (error) {
            console.log("Error al obtener datos de la url: " + rootPath + "MantRolFuncionalidad/guardarFuncionalidad");
            msgBox('Hubo un problema al guardar datos.', 'warning', 'Error');
            $("#wait-dialog").modal("hide");
        }
    });
}