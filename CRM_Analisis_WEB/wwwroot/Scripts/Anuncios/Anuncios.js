
function generarTabla() {
    $("#contTable").empty();
    mtGenerarTabla(arrayAnuncio, "tblAnuncio", "contTable", "titulosAnuncio", "valoresAnuncio");
    $('#tblAnuncio').DataTable();
    var arrayNotOrder = [9];
    mtRecuperarDatosTablaPersonalizada("/Marketing/ObtenerAnuncios", null, "Account/Login", "tblAnuncio", "valoresAnuncio", arrayNotOrder);
}

function agregarAnuncio() {

    var encabezado = $("#funcEncabezado").val();
    var descripcion = $("#funcDescripcion").val();
    var punto_venta = $("#funcPuntoVenta").val();
    var precio = $("#funcPrecio").val();
    var producto = document.getElementById("selectProducto").value;
    var tipo_Edad = document.getElementById("selectTipoEdad").value;
    var tipo_Promocion = document.getElementById("selectTipoPromocion").value;
    var tipo_Categoria = document.getElementById("selectTipoCategoria").value;

    if (encabezado.length > 50 || punto_venta.length > 50  || precio < 0) {

        if (encabezado.length > 50) {
            swal("¡Error!", "El tamaño del texto de Encabezado no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (punto_venta.length > 50 ) {
            swal("¡Error!", "El tamaño del texto de Punto de Venta no puede ser mayor a 50.", "warning");
            return false;
        } else if (precio < 0) {
            swal("¡Error!", "El campo Precio no puede tener valores negativos", "warning");
            return false;
        }

    }
    else {
        if (encabezado === undefined || encabezado === null || encabezado === "") {
            swal("¡Error!", "Es necesario ingresar la encabezado.", "warning");
            return false;
        } else {
            $.ajax({
                type: "POST",
                url: rootPath + '/Marketing/GuardarAnuncio',
                data: {
                    Encabezado: encabezado, Descripcion: descripcion, Punto_venta: punto_venta, Precio: precio, Producto: { Id: producto }, tipo_Edad: { Id: tipo_Edad }, tipo_Promocion: { Id: tipo_Promocion }, tipo_Categoria: { Id: tipo_Categoria }
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcEncabezado").val("");
                        $("#funcDescripcion").val("");
                        $("#funcPuntoVenta").val("");
                        $("#funcPrecio").val("");
                        $("#selectProducto").val("").change();
                        $("#selectTipoEdad").val("").change();
                        $("#selectTipoPromocion").val("").change();
                        $("#selectTipoCategoria").val("").change();

                        $("#modalCrearAnuncio").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearAnuncio").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos de Anuncio. ', 'warning');
                    $("#modalCrearAnuncio").modal('show');
                    return false;
                }
            });

        }
    }
}


function detalleModificarAnuncio(id) {
    if (id > 0) {
        $.ajax({
            type: "POST",
            url: rootPath + '/Marketing/DetalleAnuncio?id=' + id,
            data: {

            },
            success: function (response) {
                if (response != null && response.success) {
                    $("#funcEncabezadoEdit").val(response.Encabezado);
                    $("#funcDescripcionEdit").val(response.Descripcion);
                    $("#funcPuntoVentaEdit").val(response.Punto_venta);
                    $("#funcPrecioEdit").val(response.Precio);
                    $("#selectProductoEdit").val(response.Producto).change();
                    $("#selectTipoEdadEdit").val(response.tipo_Edad).change();
                    $("#selectTipoPromocionEdit").val(response.tipo_Promocion).change();
                    $("#selectTipoCategoriaEdit").val(response.tipo_Categoria).change();
                    $("#funcId").val(id);
                    $("#modalEditAnuncio").modal('show');
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
    var encabezado = $("#funcEncabezadoEdit").val();
    var descripcion = $("#funcDescripcionEdit").val();
    var punto_venta = $("#funcPuntoVentaEdit").val();
    var precio = $("#funcPrecioEdit").val();
    var producto = document.getElementById("selectProductoEdit").value;
    var tipo_Edad = document.getElementById("selectTipoEdadEdit").value;
    var tipo_Promocion = document.getElementById("selectTipoPromocionEdit").value;
    var tipo_Categoria = document.getElementById("selectTipoCategoriaEdit").value;

    if (encabezado.length > 50 || punto_venta.length > 50 || precio < 0) {

        if (descripcion.length > 50) {
            swal("¡Error!", "El tamaño del texto de descripción no puede ser mayor a 50.", "warning");
            return false;
        }
        else if (encabezado.length > 50) {
            swal("¡Error!", "El tamaño del texto de descripción no puede ser mayor a 50.", "warning");
            return false;
        } else if (precio < 0) {
            swal("¡Error!", "El campo cantidad no puede tener valores negativos", "warning");
            return false;
        }

    }
    else {
        if (encabezado === undefined || encabezado === null || encabezado === "") {
            swal("¡Error!", "Es necesario ingresar la descripción.", "warning");
            return false;
        } else {
            $.ajax({
                type: "POST",
                url: rootPath + '/Marketing/ModificarAnuncio',
                data: {
                    Id: id, Encabezado: encabezado, Descripcion: descripcion, Punto_venta: punto_venta, Precio: precio, producto: { Id: producto }, tipo_Edad: { Id: tipo_Edad }, tipo_Promocion: { Id: tipo_Promocion }, tipo_Categoria: { Id: tipo_Categoria }
                },
                success: function (response) {
                    if (response != null && response.success) {
                        msgBox(response.responseText, 'success');
                        $("#funcId").val("");
                        $("#funcEncabezadoEdit").val("");
                        $("#funcDescripcionEdit").val("");
                        $("#funcPuntoVentaEdit").val("");
                        $("#funcPrecioEdit").val("");
                        $("#selectProductoEdit").val("").change();
                        $("#selectTipoEdadEdit").val("").change();
                        $("#selectTipoPromocionEdit").val("").change();
                        $("#selectTipoCategoriaEdit").val("").change();

                        $("#modalCrearAnuncio").modal('hide');
                        generarTabla();
                        return true;

                    }
                    else {
                        msgBox(response.responseText, 'warning');
                        $("#modalCrearAnuncio").modal('show');
                        return false;
                    }
                },
                error: function (response) {
                    msgBox('Hubo un problema al guardar los datos del Anuncio. ', 'warning');
                    $("#modalCrearAnuncio").modal('show');
                    return false;
                }
            });

        }
    }
}

function EliminarAnuncio(id) {
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
                    url: rootPath + '/Marketing/EliminarAnuncio',
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
        var forms = $('.validarAnuncio');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                    form.classList.add('was-validated');
                }
                else {
                    event.preventDefault();
                    agregarAnuncio();
                    $("#formCrearAnuncio").removeClass("was-validated");
                    $("#modalCrearAnuncio").modal('hide');
                }
            }, false);
        });
    }, false);
})();

(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = $('.validarAnuncioUpdate');
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
                    $("#formEditAnuncio").removeClass("was-validated");
                    $("#modalEditAnuncio").modal('hide');
                }
            }, false);
        });
    }, false);
})();