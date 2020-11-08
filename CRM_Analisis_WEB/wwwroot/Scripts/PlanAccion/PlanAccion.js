function generarTabla() {
    $("#contTable").empty();
    mtGenerarTabla(arrayPlanAccion, "tblPlanAccion", "contTable", "titulosPlanAccion", "valoresPlanAccion");
    $('#tblPlanAccion').DataTable();
    var arrayNotOrder = [8];
    mtRecuperarDatosTablaPersonalizada("/PlanAccion/ObtenerPlanAccion", null, "Account/Login", "tblPlanAccion", "valoresPlanAccion", arrayNotOrder);
}

function agregarPlanAccion() {

    var productoservicio = $("#funcServicio").val();
    var recursosnecesarios = $("#funcRecursos").val();
    var descuentosofertas = $("#funcDescuentos").val();
    var plandeentrega = $("#funcPlanEntrega").val();
    var nombreencargado = $("#funcResponsable").val();
    var producto = document.getElementById("selectProducto").value;
    var nivelcontrol = document.getElementById("selectNivelControl").value;

    if (productoservicio.length > 50 || recursosnecesarios < 0 || plandeentrega.length > 50 || nombreencargado.length > 50) {

        if (productoservicio.length > 50) {
            swal("¡Error!", "El tamaño del texto de Producto/Servicio no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (recursosnecesarios < 0) {
            swal("¡Error!", "El campo precio no puede tener valores negativos", "warning");
            return false;
        } else if (plandeentrega.length > 50) {
            swal("¡Error!", "El tamaño del texto de Plan de Entrega no puede ser mayor a 50.", "warning");
            return false;
        } else if (nombreencargado.length > 50) {
            swal("¡Error!", "El tamaño del texto de Nombre de Encargado no puede ser mayor a 50.", "warning");
            return false;
        }

    }
    else {
        if (productoservicio === undefined || productoservicio === null || productoservicio === "") {
            swal("¡Error!", "Es necesario ingresar la Producto/Servicio.", "warning");
            return false;
        } else {
            $.ajax({
                type: "POST",
                url: rootPath + '/PlanAccion/GuardarPlanAccion',
                data: {
                    ProductoServicio: productoservicio, RecursosNecesarios: recursosnecesarios, DescuentosOfertas: descuentosofertas, PlandeEntrega: plandeentrega, NombreEncargado: nombreencargado, Producto: { Id: producto }, NivelControl: { Id: nivelcontrol }
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcServicio").val("");
                        $("#funcRecursos").val("");
                        $("#funcDescuentos").val("");
                        $("#funcPlanEntrega").val("");
                        $("#funcResponsable").val("");
                        $("#selectProducto").val("").change();
                        $("#selectNivelControl").val("").change();

                        $("#modalCrearPlanAccion").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearPlanAccion").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos de Plan Accion. ', 'warning');
                    $("#modalCrearPlanAccion").modal('show');
                    return false;
                }
            });

        }
    }
}


function detalleModificarPlanAccion(id) {
    if (id > 0) {
        $.ajax({
            type: "POST",
            url: rootPath + '/PlanAccion/DetallePlanAccion?id=' + id,
            data: {

            },
            success: function (response) {
                if (response != null && response.success) {
                    $("#funcServicioEdit").val(response.ProductoServicio);
                    $("#funcRecursosEdit").val(response.RecursosNecesarios);
                    $("#funcDescuentosEdit").val(response.DescuentosOfertas);
                    $("#funcPlanEntregaEdit").val(response.PlandeEntrega);
                    $("#funcResponsableEdit").val(response.NombreEncargado);
                    $("#selectProductoEdit").val(response.Producto).change();
                    $("#selectNivelControlEdit").val(response.NivelControl).change();
                    $("#funcId").val(id);
                    $("#modalEditPlanAccion").modal('show');
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
    var productoservicio = $("#funcServicioEdit").val();
    var recursosnecesarios = $("#funcRecursosEdit").val();
    var descuentosofertas = $("#funcDescuentosEdit").val();
    var plandeentrega = $("#funcPlanEntregaEdit").val();
    var nombreencargado = $("#funcResponsableEdit").val();
    var producto = document.getElementById("selectProductoEdit").value;
    var nivelcontrol = document.getElementById("selectNivelControlEdit").value;

    if (productoservicio.length > 50 || recursosnecesarios < 0 || plandeentrega.length > 50 || nombreencargado.length > 50) {

        if (productoservicio.length > 50) {
            swal("¡Error!", "El tamaño del texto de Producto/Servicio no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (recursosnecesarios < 0) {
            swal("¡Error!", "El campo precio no puede tener valores negativos", "warning");
            return false;
        } else if (plandeentrega.length > 50) {
            swal("¡Error!", "El tamaño del texto de Plan de Entrega no puede ser mayor a 50.", "warning");
            return false;
        } else if (nombreencargado.length > 50) {
            swal("¡Error!", "El tamaño del texto de Nombre de Encargado no puede ser mayor a 50.", "warning");
            return false;
        }

    }
    else {
        if (productoservicio === undefined || productoservicio === null || productoservicio === "") {
            swal("¡Error!", "Es necesario ingresar la Producto/Servicio.", "warning");
            return false;
        } else {
            $.ajax({
                type: "POST",
                url: rootPath + '/PlanAccion/GuardarPlanAccion',
                data: {
                    ProductoServicio: productoservicio, RecursosNecesarios: recursosnecesarios, DescuentosOfertas: descuentosofertas, PlandeEntrega: plandeentrega, NombreEncargado: nombreencargado, Producto: { Id: producto }, NivelControl: { Id: nivelcontrol }
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcServicio").val("");
                        $("#funcRecursos").val("");
                        $("#funcDescuentos").val("");
                        $("#funcPlanEntrega").val("");
                        $("#funcResponsable").val("");
                        $("#selectProducto").val("").change();
                        $("#selectNivelControl").val("").change();

                        $("#modalCrearPlanAccion").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearPlanAccion").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos de Plan Accion. ', 'warning');
                    $("#modalCrearPlanAccion").modal('show');
                    return false;
                }
            });

        }
    }
}

function EliminarPlanAccion(id) {
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
                    url: rootPath + '/PlanAccion/EliminarPlanAccion',
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
        msgBox('Es necesario conocer los detalles del Plan de Accion.', "error");
        return false;
    }
}

(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = $('.validarPlanAccion');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                    form.classList.add('was-validated');
                }
                else {
                    event.preventDefault();
                    agregarPlanAccion();
                    $("#formCrearPlanAccion").removeClass("was-validated");
                    $("#modalCrearPlanAccion").modal('hide');
                }
            }, false);
        });
    }, false);
})();

(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = $('.validarPlanAccionUpdate');
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
                    $("#formEditPlanAccion").removeClass("was-validated");
                    $("#modalEditPlanAccion").modal('hide');
                }
            }, false);
        });
    }, false);
})();