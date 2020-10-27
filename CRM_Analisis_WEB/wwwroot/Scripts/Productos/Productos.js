
function generarTabla() {
    $("#contTable").empty();
    mtGenerarTabla(arrayProducto, "tblProducto", "contTable", "titulosProducto", "valoresProduto");
    $('#tblProducto').DataTable();
    var arrayNotOrder = [4];
    mtRecuperarDatosTablaPersonalizada("/Productos/ObtenerProductos", null, "Account/Login", "tblProducto", "valoresProduto", arrayNotOrder);
}