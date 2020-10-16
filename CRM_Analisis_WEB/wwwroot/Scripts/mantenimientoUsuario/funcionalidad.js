function mostrarFuncionalidad() {
    var table = $('#tblFuncionalidad').DataTable();
    var estado = "";
    var botonEstado = "";
    table.destroy();
    //$("#wait-dialog").modal("show");
    $.ajax({
        url: 'https://localhost:44322/MantRolFuncionalidad/ObtenerFuncionalidades',
        type: "POST",
        data: {},
        success: function (data) {
            var sessionActiva = -1;
            try {
                sessionActiva = data.indexOf("SignIn?ReturnUrl");
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

                        if (obj.Activo == "True") {
                            estado = "Activo";
                            botonEstado = '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Desactivar" onclick="cambiarEstado(' + obj.Id + ', 1)"><i class="fa fa-toggle-on"></i></button> ';
                        }
                        else {
                            estado = "No Activo";
                            botonEstado = '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Activar" onclick="cambiarEstado(' + obj.Id + ', 0)"><i class="fa fa-toggle-off"></i></button> ';
                        }

                        $("#valorFunc" + obj.Id).remove();
                        $('#valoresFuncion').append('<tr id="valorFunc' + obj.Id + '">' +
                            '<td>' + obj.Id + '</td>' +
                            '<td>' + obj.Descripcion + '</td>' +
                            '<td>' + obj.NombreMenu + '</td>' +
                            '<td>' + obj.Url + '</td>' +
                            '<td><i class="' + obj.Imagen + '"></i></button></td>' +
                            '<td>' + obj.Observaciones + '</td>' +
                            '<td>' + obj.FuncionalidadHijo + '</td>' +
                            '<td id="idEstadoFunc' + obj.id + '">' + estado + '</td>' +
                            '<td>' +
                            '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="Editar" onclick="modificarRegistroFunc(' + obj.Id + ',\'' + obj.Descripcion + '\',\'' + obj.Url + '\',\'' + obj.Imagen + '\',\'' + obj.Observaciones + '\',\'' + obj.IdFuncionalidad + '\',\'' + obj.NombreMenu + '\')"><i class="fa fa-edit"></i></button> ' +
                            botonEstado +
                            '<button class="btn btn-danger" data-toggle="tooltip" data-placement="bottom" title="Eliminar" onclick="EliminarRegistroFuncionalidad(' + obj.Id + ',true)"><i class="fa fa-trash-o"></i></button> ' +
                            "<button class=\"btn\" data-toggle=\"tooltip\" data-placement=\"bottom\" title=\"Atributos\" onclick=\"AddAtributo('" + obj.Id + "*Seguridad_Funcionalidad')\"><i class=\"fa fa-tags\"></i></button> " +
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
                window.location.replace(rootPath + "ServiceLogin/SignIn?ReturnUrl=%2fmantenimientos%2fmantRolUsuarioFunc");
            }
        },
        error: function (error) {
            console.log("Error al obtener datos de la url: " + rootPath + "mantenimientos/buscarFuncionalidades");
            msgBox('Hubo un problema al consultar datos.', 'error');
        }
    });

    $("#funcDescripcion").val('');
    $("#funcNombreMenu").val('');
    $("#funcUrl").val('');
    $("#funcImagen").val('');
    $("#funcObservaciones").val('');
}