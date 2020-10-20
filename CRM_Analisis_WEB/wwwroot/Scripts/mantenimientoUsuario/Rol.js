function mostrarRol() {
    var table = $('#tblRol').DataTable();
    var estado = "";
    var botonEstado = "";
    table.destroy();
    //$("#wait-dialog").modal("show");
    $.ajax({
        url: rootPath + '/MantRolFuncionalidad/ObtenerRol',
        type: "POST",
        data: {},
        success: function (data) {
            var sessionActiva = -1;
            try {
                var sessionActiva = data.indexOf("Login?ReturnUrl");
            } catch (e) {
                var sessionActiva = -1;
            }

            if (sessionActiva == -1) {

                if (data[0].Message != null) {
                    msgBox(data[0].Message, 'error');
                }
                else {
                    $('#valoresRol').empty();
                    data.forEach(function (obj) {
                        if (obj.Estado == 1) {
                            estado = "Activo";
                            botonEstado = '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Desactivar" onclick="cambiarEstadoRol(' + obj.Id + ', 1)"><i class="fa fa-toggle-on"></i></button> ';
                        }
                        else {
                            estado = "No Activo";
                            botonEstado = '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Activar" onclick="cambiarEstadoRol(' + obj.Id + ', 0)"><i class="fa fa-toggle-off"></i></button> ';
                        }
                        if (obj.Name == null) { obj.Name = "" }
                        if (obj.Descripcion == null) { obj.Descripcion = "" }

                        $("#valorRol" + obj.Id).remove();
                        $('#valoresRol').append('<tr id="valorRol' + obj.Id + '">' +
                            '<td>' + obj.Id + '</td>' +
                            '<td>' + obj.Name + '</td>' +
                            '<td>' + obj.Descripcion + '</td>' +
                            '<td>' + estado + '</td>' +
                            '<td>' +
                            '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Editar" onclick="modificarRegistroRol(' + obj.Id + ',\'' + obj.Descripcion + '\',\'' + obj.Observaciones + '\')"><i class="fa fa-edit"></i></button> ' +
                            botonEstado +
                            "<button class=\"btn\" data-toggle=\"tooltip\" data-placement=\"bottom\" title=\"Asignar Funcionalidad\" onclick=\"asignarFunct('" + obj.Id + "')\"><i class=\"fa fa-paperclip\"></i></button> " +
                            '<button class="btn btn-danger" data-toggle="tooltip" data-placement="bottom" title="Eliminar" onclick="EliminarRegistroFuncRol(' + obj.Id + ',true)"><i class="fa fa-trash-o"></i></button> ' +
                            '</td>' +
                            '</tr>');
                    });
                    $('#tblRol').DataTable();
                }
            }
            else {
                window.location.replace(rootPath + "Account/Login?ReturnUrl=%MantRolFuncionalidad%2fmantRolUsuarioFunc");
            }

        },
        error: function (error) {
            console.log("Error al obtener datos de la url: " + rootPath + "/MantRolFuncionalidad/ObtenerRol");
            msgBox('Hubo un problema al consultar datos.', 'warning', 'Error');
        }
    });
    $("#txtDescRol").val('');
    $("#txtObservRol").val('');
}

function mantenimientoRol() {
    if (idRol != 0) {
        $("#txtDescRol").val('');
        $("#txtObservRol").val('');
        idRol = 0;
    }
    $("#dvAttrObj2").hide();
    
    setTimeout(function () { $('input[name="txtDescripcioniRol"]').focus() }, 600);
}

function guardarEditarRol() {
    if (idRol != 0) {
        editarDatosRol();
    }
    else {
        guardarDatosRol();
    }

}

function guardarDatosRol() {
    var descripcion = $("#txtDescRol").val();
    var observaciones = $("#txtObservRol").val();
    $("#wait-dialog").modal("show");

    $.ajax({
        url: rootPath + '/MantRolFuncionalidad/guardarRol',
        type: "POST",
        data: { Name: descripcion, Descripcion: observaciones, Estado: true },
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
                    mostrarRol();
                    $('#rolModal').modal('hide');
                }
                else {
                    if (data.Message != '' && data.Message != null && data.Message != 'undefined') {
                        msgBox(data.Message, 'error');
                    }
                    else {
                        msgBox('Registro no guardado.', 'error');
                    }
                }
            }
            else {
                window.location.replace(rootPath + "Account/Login?ReturnUrl=%MantRolFuncionalidad%2fmantRolUsuarioFunc");
            }
            $("#wait-dialog").modal("hide");
        },
        error: function (error) {
            console.log("Error al obtener datos de la url: " + rootPath + "/MantRolFuncionalidad/guardarRol");
            msgBox('Hubo un problema al guardar datos.', 'error', 'Error');
            $("#wait-dialog").modal("hide");
        }
    });
}

var tree;

function asignarFunct(id) {
    idRol = id;
    $("#tree").remove();
    $("#treeView").append('<div id="tree"></div>');

    tree = $('#tree').tree({
        primaryKey: 'id',
        uiLibrary: 'bootstrap4',
        dataSource: rootPath + '/MantRolFuncionalidad/obtenerFunct/' + id,
        checkboxes: true
    });

    $('#rolFuncModal').modal('show');
}
