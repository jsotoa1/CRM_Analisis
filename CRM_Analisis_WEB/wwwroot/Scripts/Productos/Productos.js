
function generarTabla() {
    $("#contTable").empty();
    mtGenerarTabla(arrayProducto, "tblProducto", "contTable", "titulosProducto", "valoresProduto");
    $('#tblProducto').DataTable();
    var arrayNotOrder = [7];
    mtRecuperarDatosTablaPersonalizada("/Productos/ObtenerProductos", null, "Account/Login", "tblProducto", "valoresProduto", arrayNotOrder);
}

function agregarProducto() {

    var nombre = $("#funcNombre").val();
    var descripcion = $("#funcDescripcion").val();
    var precio = $("#funcPrecio").val();
    var cantidad = $("#funcCantidad").val();
    var categoria = document.getElementById("selectCategoria").value;
    var Activo = document.getElementById("check1").checked;

    if (nombre.length > 50 || precio < 0 || cantidad <0) {

        if (descripcion.length > 50) {
            swal("¡Error!", "El tamaño del texto de descripción no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (precio < 0) {
            swal("¡Error!", "El campo precio no puede tener valores negativos", "warning");
            return false;
        } else if (cantidad < 0){
            swal("¡Error!", "El campo cantidad no puede tener valores negativos", "warning");
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
                url: rootPath + '/Productos/GuardarProducto',
                data: {
                    Nombre: nombre, Descripcion: descripcion, Precio: precio, Cantidad: cantidad, Categoria: { Id: categoria }, Estado: Activo
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcNombre").val("");
                        $("#funcDescripcion").val("");
                        $("#funcPrecio").val("");
                        $("#funcCantidad").val("");
                        $("#selectCategoria").val("").change();
                        $("#check1").prop('checked', true).change();

                        $("#modalCrearProducto").modal('hide');
                        generarTabla();
                        return true;
                        
                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearProducto").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos de producto. ', 'warning');
                    $("#modalCrearProducto").modal('show');
                    return false;
                }
            });

        }
    }
}


function detalleModificarProducto(id) {
    if (id > 0) {
        $.ajax({
            type: "POST",
            url: rootPath + '/Productos/DetalleProducto?id=' + id,
            data: {
           
            },
            success: function (response) {
                if (response != null && response.success) {
                    $("#funcNombreEdit").val(response.Nombre);
                    $("#funcDescripcionEdit").val(response.Descripcion);
                    $("#funcPrecioEdit").val(response.Precio);
                    $("#funcCantidadEdit").val(response.Cantidad);
                    $("#selectCategoriaEdit").val(response.Categoria).change();
                    $("#check1Edit").prop('checked', response.Estado).change();
                    $("#funcId").val(id);
                    $("#modalEditProducto").modal('show');
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
    var nombre = $("#funcNombreEdit").val();
    var descripcion = $("#funcDescripcionEdit").val();
    var precio = $("#funcPrecioEdit").val();
    var cantidad = $("#funcCantidadEdit").val();
    var categoria = document.getElementById("selectCategoriaEdit").value;
    var Activo = document.getElementById("check1Edit").checked;

    if (nombre.length > 50 || precio < 0 || cantidad < 0) {

        if (descripcion.length > 50) {
            swal("¡Error!", "El tamaño del texto de descripción no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (precio < 0) {
            swal("¡Error!", "El campo precio no puede tener valores negativos", "warning");
            return false;
        } else if (cantidad < 0) {
            swal("¡Error!", "El campo cantidad no puede tener valores negativos", "warning");
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
                url: rootPath + '/Productos/ModificarProducto',
                data: {
                    Id: id, Nombre: nombre, Descripcion: descripcion, Precio: precio, Cantidad: cantidad, Categoria: { Id: categoria }, Estado: Activo
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcId").val("");
                        $("#funcNombreEdit").val("");
                        $("#funcDescripcionEdit").val("");
                        $("#funcPrecioEdit").val("");
                        $("#funcCantidadEdit").val("");
                        $("#selectCategoriaEdit").val("").change();
                        $("#check1Edit").prop('checked', true).change();

                        $("#modalCrearProducto").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearProducto").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos de producto. ', 'warning');
                    $("#modalCrearProducto").modal('show');
                    return false;
                }
            });

        }
    }
}

function EliminarProducto(id) {
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
                    url: rootPath + '/Productos/EliminarProducto',
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
        var forms = $('.validarProducto');
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
                    $("#formCrearProducto").removeClass("was-validated");
                    $("#modalCrearProducto").modal('hide');
                }
            }, false);
        });
    }, false);
})();

(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = $('.validarProductoUpdate');
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
                    $("#formEditProducto").removeClass("was-validated");
                    $("#modalEditProducto").modal('hide');
                }
            }, false);
        });
    }, false);
})();