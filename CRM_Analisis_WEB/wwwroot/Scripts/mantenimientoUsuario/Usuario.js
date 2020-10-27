function mostrarUsuario() {
    var table = $('#tblUsuario').DataTable();
    var estado = "";
    var botonEstado = "";
    var usuario = "";
    var resUsuario = "";

    table.destroy();
    //$("#wait-dialog").modal("show");
    $.ajax({
        url: rootPath + '/MantRolFuncionalidad/ObtenerUsuarios',
        type: "POST",
        data: {},
        success: function (data) {
            $('#valoresUsuario').empty();
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
                    data.forEach(function (obj) {
                        if (obj.estado == 1) {
                            estado = "Activo";
                            botonEstado = '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Dar de Baja" onclick="cambiarEstadoUsuario(\'' + obj.usuario + '\', 1)"><i class="fa fa-toggle-on"></i></button> ';
                        }
                        else {
                            estado = "No Activo";
                            botonEstado = '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Dar de alta" onclick="cambiarEstadoUsuario(\'' + obj.usuario + '\', 0)"><i class="fa fa-toggle-off"></i></button> ';
                        }
                        usuario = obj.UserName;
                        resUsuario = usuario.replace(/\./g, '-').replace(/\-/g, '_').replace(/@/g, '_');
                        $("#v" + resUsuario).remove();
                        $('#valoresUsuario').append('<tr id="v' + resUsuario + '">' +
                            '<td>' + obj.UserName + '</td>' +
                            '<td>' + obj.FullName + '</td>' +
                            '<td>' + obj.Email + '</td>' +
                            '<td>' + obj.rol.Name + '</td>' +
                            '<td>' + estado + '</td>' +
                            '<td>' +
                            '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Editar" onclick="modificarRegistroUsuario(\'' +
                            obj.UserName + '\',\'' + obj.Nombre + '\',\'' + obj.Apellido +
                            '\',\'' + obj.Email +
                            '\',\'' + obj.rol.Id + '\',\'' + obj.AutenticaAD +  '\',\'' + obj.CaducidadContrasenia + '\')"><i class="fa fa-edit"></i></button> ' +
                            botonEstado +
                            '<button class="btn btn-danger" data-toggle="tooltip" data-placement="bottom" title="Eliminar" onclick="EliminarRegistroFuncUsuario(\'' + obj.usuario + '\',true)"><i class="fa fa-trash-o"></i></button> ' +  
                            '</td>' +
                            '</tr>');
                    });
                    $('#tblUsuario').DataTable();
                }
            }
            else {
                window.location.replace(rootPath + "ServiceLogin/SignIn?ReturnUrl=%2fmantenimientos%2fmantRolUsuarioFunc");
            }

        },
        error: function (error) {
            console.log("Error al obtener datos de la url: " + rootPath + "mantenimientos/buscarUsuario");
            msgBox('Hubo un problema al consultar datos.', 'error', 'Error');
        }
    });
    $("#txtUsuario").val('');
    $("#txtUsuarioPass").val('');
    $("#txtUsuarioPassConf").val('');
    $("#txtPnombre").val('');
    $("#txtSnombre").val('');
    $("#txtPapellido").val('');
    $("#txtSapellido").val('');
    $("#txtCorreoElectronico").val('');
}

function listaRoles() {
    $("#wait-dialog").modal("show");
    $.ajax({
        url: rootPath + '/MantRolFuncionalidad/ObtenerRol',
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
                    $('#listRolesUsuario').append('<option id="opcFunc0" value="" disabled selected>Seleccione Rol</option>');
                    data.forEach(function (obj) {
                        $("#opcFunc" + obj.Id).remove();
                        $('#listRolesUsuario').append('<option id="opcFunc' + obj.Id + '" value="' + obj.Id + '">' + obj.Name + '</option>');
                    });
                }
            }
            else {
                window.location.replace(rootPath + "Account/Login?ReturnUrl=%MantRolFuncionalidad%2fmantRolUsuarioFunc");
            }

        },
        error: function (error) {
            $("#wait-dialog").modal("hide");
            console.log("Error al obtener datos de la url: " + rootPath + "MantRolFuncionalidad/ObtenerRol");
            msgBox('Hubo un problema al consultar datos de roles.', 'warning', 'Error');
        }
    });
}

function guardarEditarUsuario() {
    if (generalUsuario != "") {
        editarUsuario();
    }
    else {
        guardarUsuario();
    }
}

function guardarUsuario() {
    $("#wait-dialog").modal("show");
    var usuarioVal = $("#txtUsuario").val();
    var usuarioPassVal = $("#txtUsuarioPass").val();
    var usuarioPassConfVal = $("#txtUsuarioPassConf").val();
    var PnombreVal = $("#txtPnombre").val();
    var SnombreVal = $("#txtSnombre").val();
    var PapellidoVal = $("#txtPapellido").val();
    var SapellidoVal = $("#txtSapellido").val();
    var idRol = $("#listRolesUsuario").val();
    var direccion = $("#txtDirec").val();
    var Doc = $("#txtDoc").val();

    $("#wait-dialog").modal("show");
    if (usuarioPassVal != "" || $("#chkautenticaad").is(':checked')) {
        if (usuarioPassVal == usuarioPassConfVal) {
            $.ajax({
                url: rootPath + '/MantRolFuncionalidad/CrearUsuario',
                type: "POST",
                data: {
                    Usuario: usuarioVal, Contrasenia: usuarioPassVal, Documento: Doc,
                    PrimerNombre: PnombreVal, SegundoNombre: SnombreVal,
                    PrimerApellido: PapellidoVal, SegundoApellido: SapellidoVal,
                    Idrol: idRol , Direccion: direccion,  estado: true

                },
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

                            mostrarUsuario();
                            $('#UsuarioModal').modal('hide');
                        }
                        else {
                            if (data.Message == "") {
                                msgBox('Registro no guardado.', 'error');
                            }
                            else {
                                msgBox(data.Message, 'error');
                            }
                        }

                    }
                    else {
                        window.location.replace(rootPath + "ServiceLogin/SignIn?ReturnUrl=%2fmantenimientos%2fmantRolUsuarioFunc");
                    }
                    $("#wait-dialog").modal("hide");

                },
                error: function (error) {
                    console.log("Error al obtener datos de la url: " + rootPath + "mantenimientos/guardarUsuario");
                    msgBox('Hubo un problema al guardar datos.', 'error', 'Error');
                    $("#wait-dialog").modal("hide");
                }
            });
        }
        else {
            $("#wait-dialog").modal("hide");
            $("#txtUsuarioPass").addClass('was-validated');
            $("#txtUsuarioPassConf").addClass('was-validated');
            msgBox("La contraseña no coincide.", "info")
        }
    }
    else {
        $("#txtUsuarioPass").addClass('was-validated');
        $("#txtUsuarioPassConf").addClass('was-validated');
        $("#wait-dialog").modal("hide");
        msgBox("Es necesario ingresar la contraseña.", "info")
    }


}