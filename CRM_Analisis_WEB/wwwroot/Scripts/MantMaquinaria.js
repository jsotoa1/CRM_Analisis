function generarTabla(flujo, id) {
    $("#contTable").empty();
    mtGenerarTabla(arraFlujo, "tblFlujo", "contTable", "titulosFlujo", "valoresFlujo");
    $('#tblFlujo').DataTable();
    var arrayNotOrder = [6];
    mtRecuperarDatosTablaPersonalizada("/MantMaquinaria/ObtenerFlujoMantMaquina?flujo="+ flujo + "&ID_Paso_Flujo=" + id, null, "Account/Login", "tblFlujo", "valoresFlujo", arrayNotOrder);
}

 
function agregarMantMaquinaria() {

    var NombreFlujo =$("#funcMant").val();
    var funIdFlujo = $("#funIdFlujo").val();
    var funcNombre = $("#funcNombre").val();
    var funcFecha = $("#funcFecha").val();
    var funcRealiza = $("#funcRealiza").val();
    var funcEmail = $("#funcEmail").val();
    var funcTiempo = $("#funcTiempo").val();
    var funcComentario = $("#funcComentario").val();

    var combo = document.getElementById("selectTipo");
    var tipo = combo.options[combo.selectedIndex].text;
   
    if (funcNombre.length > 100 || funcFecha.length > 100 || funcRealiza.length > 100 || funcEmail.length > 100 || funcTiempo.length > 50 || funcComentario.length > 200) {

        if (funcNombre.length > 100) {
            swal("¡Error!", "El tamaño del texto de nombre no puede ser mayor a 50.", "warning");
            return false;
        }
    }
    else {
        if (funcNombre === undefined || funcNombre === null || funcNombre === "") {
            swal("¡Error!", "Es necesario ingresar el Nombre.", "warning");
            return false;
        } else {
            $.ajax({
                type: "POST",
                url: rootPath + '/MantMaquinaria/GuardarMantMaquinaria',
                data: {
                    Nombre_Flujo: NombreFlujo, Id_Paso_Flujo: funIdFlujo, Nombre_Paso_Fujo: funcNombre, Persona_Realiza: funcRealiza, Tiempo_Tomado: funcTiempo, Comentario: funcComentario, Email: funcEmail, Fecha: funcFecha, Tipo: tipo
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funIdFlujo").val("");
                        $("#funcNombre").val("");
                        $("#funcFecha").val("");
                        $("#funcRealiza").val("");
                        $("#funcEmail").val("");
                        $("#funcTiempo").val("");
                        $("#funcComentario").val("");

                        $("#modalGuardarMantMaquina").modal('hide');
                        //generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalGuardarMantMaquina").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos del flujo. ', 'warning');
                    $("#modalGuardarMantMaquina").modal('show');
                    return false;
                }
            });

        }
    }
}

(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = $('.validarFlujo');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                    form.classList.add('was-validated');
                }
                else {
                    event.preventDefault();
                    agregarMantMaquinaria();
                    $("#formAddFlujo").removeClass("was-validated");
                    $("#modalGuardarMantMaquina").modal('hide');
                }
            }, false);
        });
    }, false);
})();