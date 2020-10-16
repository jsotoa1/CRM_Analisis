function mtGenerarTabla(nombresColumnas, idTabla, divDestino, idEncabezado, idFila) {
    $('#' + divDestino).append(
        '<div class="col-sm-12 col-md-12 col-xl-12">' +
        '<table id="' + idTabla + '" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">' +
        '<thead>' +
        '<tr id="' + idEncabezado + '">' +
        '</tr>' +
        '</thead>' +
        '<tbody id="' + idFila + '"></tbody>' +
        '</table>' +
        '</div>');
    var contador = 0;
    nombresColumnas.forEach(function (element) {
        var nombresValores = nombresColumnas[contador].split("|")
        if (nombresValores[1] == "1") {
            var nombresValoresProp = nombresColumnas[contador].split("@")
            if (nombresValoresProp[1] == "1") {
                var esTooltip = nombresColumnas[contador].split("(");
                if (esTooltip[1] == "1") {
                    $('#' + idEncabezado).append('<th class="none" title="' + esTooltip[2] + '"width="auto" style="hidden">' + esTooltip[0] + '</th>');
                } else {
                    $('#' + idEncabezado).append('<th class="none" "width="auto" style="hidden">' + nombresValores[0] + '</th>');
                }
            } else {
                var esTooltip = nombresColumnas[contador].split("(");
                if (esTooltip[1] == "1") {
                    $('#' + idEncabezado).append('<th class="none" title="' + esTooltip[2] + '" style="hidden">' + esTooltip[0] + '</th>');
                } else {
                    $('#' + idEncabezado).append('<th class="none">' + nombresValores[0] + '</th>');
                }
            }
        }
        else {
            var nombresValoresProp = nombresColumnas[contador].split("@")
            if (nombresValoresProp[1] == "1") {
                var esTooltip = nombresColumnas[contador].split("(");
                if (esTooltip[1] == "1") {
                    $('#' + idEncabezado).append('<th class="all" title="' + esTooltip[2] + '" style="hidden">' + esTooltip[0] + '</th>');
                } else {
                    $('#' + idEncabezado).append('<th class="all" style="display:none;">' + nombresValores[0] + '</th>');
                }
            } else {
                var esTooltip = nombresColumnas[contador].split("(");
                if (esTooltip[1] == "1") {
                    $('#' + idEncabezado).append('<th class="all" title="' + esTooltip[2] + '" style="hidden">' + esTooltip[0] + '</th>');
                } else {
                    $('#' + idEncabezado).append('<th class="all">' + nombresValores[0] + '</th>');
                }
            }
        }

        contador++;
    });
}

function mtRecuperarDatosTabla(varUrl, varData, redirect, nombreTabla, idFila, arrayNotOrder) {
    if (varData == null) {
        varData = {};
    }
    var table = $('#' + nombreTabla).DataTable();
    var generarColumna = "";
    var nuevaFila = false;

    table.destroy();
    $.ajax({
        url: rootPath + varUrl,
        type: "POST",
        data: varData,
        success: function (data) {
            $("#wait-dialog").modal("hide");
            var sessionActiva = -1;
            try {
                sessionActiva = data.indexOf("SignIn?ReturnUrl");
            } catch (e) {
                sessionActiva = -1;
            }
            if (sessionActiva == -1) {
                try {
                    generarColumna = "<tr>"
                    data.forEach(function (obj) {
                        if (nuevaFila) {
                            generarColumna = generarColumna + "</tr><tr>";
                            nuevaFila = false;
                        }

                        if (!obj.esBtn) {
                            generarColumna = generarColumna + '<td>' + obj.valorColumna + '</td>';
                        }
                        else {
                            if (obj.objetoBtn_ != null) {
                                generarColumna = generarColumna + '<td>';
                                obj.objetoBtn_.forEach(function (objBtn) {
                                    if (objBtn.Class != NaN || objBtn.Class != "") {
                                        var atributo = "";
                                        if (objBtn.atributo != NaN || objBtn.atributo != "") {
                                            atributo = objBtn.atributo;
                                        } else {
                                            atributo = "";
                                        }
                                        generarColumna = generarColumna + '<button class="btn ' + objBtn.Class + '" data-toggle="tooltip" data-placement="bottom" title="' + objBtn.tituloBtn + '" onclick="' + objBtn.funcionJs + '(\'' + objBtn.id + '\')"  ' + atributo + '><i class="' + objBtn.icono + '"></i></button>';
                                    }
                                    else {
                                        var atributo = "";
                                        if (objBtn.atributo != NaN || objBtn.atributo != "") {
                                            atributo = objBtn.atributo;
                                        } else {
                                            atributo = "";
                                        }
                                        generarColumna = generarColumna + '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="' + objBtn.tituloBtn + '" onclick="' + objBtn.funcionJs + '(\'' + objBtn.id + '\')"  ' + atributo + '><i class="' + objBtn.icono + '"></i></button>';
                                    }
                                });

                                nuevaFila = true;
                            } else {
                                nuevaFila = true;
                            }
                        }
                    });

                    generarColumna = generarColumna + "</tr>";
                    $('#' + idFila).append(generarColumna);
                    if (arrayNotOrder === undefined) {
                        $('#' + nombreTabla).DataTable({
                            "order": [[0, "desc"]],
                            "language": {
                                "emptyTable": "No existen datos que mostrar."
                            }
                        });
                    }
                    else {
                        $('#' + nombreTabla).DataTable({
                            "columnDefs": [{
                                "targets": arrayNotOrder,
                                "orderSequence": false

                            }],
                            "language": {
                                "emptyTable": "No existen datos que mostrar."
                            },
                            "order": [[0, "desc"]],
                        });
                    }
                    return true;
                } catch (e) {
                    $('#' + nombreTabla).empty();
                    swal("No existen datos que mostrar.", "", "info");
                    return false;
                }

            }
            else {
                swal("La sesión ha expirado.", "", "danger");
                window.location.replace(rootPath + redirect);
            }
        }
    });
}

let CloseLoad = false;
function mtRecuperarDatosTablaPersonalizada(varUrl, varData, redirect, nombreTabla, idFila, arrayNotOrder, paginacion) {
    if (varData == null) {
        varData = {};
    }
    var table = $('#' + nombreTabla).DataTable();
    var generarColumna = "";
    var nuevaFila = false;

    table.destroy();
    $.ajax({
        url: rootPath + varUrl,
        type: "POST",
        data: varData,
        success: function (data) {
            if (!CloseLoad) {
                console.log('Close load');
                $("#wait-dialog").modal("hide");
            } 
            if (data.Response != undefined) {
                //notify(data.Message, data.Type, data.Title);
                $('#' + nombreTabla).DataTable({
                    "columnDefs": [{
                        "targets": arrayNotOrder,
                        "orderSequence": false

                    }],
                    "language": {
                        "emptyTable": data.Message
                    },
                    "order": [[0, "desc"]],
                    "paging": false,
                });
            }
            else {
                var sessionActiva = -1;
                try {
                    sessionActiva = data.indexOf("SignIn?ReturnUrl");
                } catch (e) {
                    sessionActiva = -1;
                }
                if (sessionActiva == -1) {
                    try {

                        generarColumna = "<tr>"
                        data.forEach(function (obj) {
                            if (nuevaFila) {
                                generarColumna = generarColumna + "</tr><tr>";
                                nuevaFila = false;
                            }

                            if (!obj.esBtn) {
                                var atributo = "";
                                if (obj.atributo != "") {
                                    atributo = obj.atributo;
                                } else {
                                    atributo = "";
                                }
                                if (obj.esInput) {
                                    if (obj.objetoInput_.inputGroup) {
                                        var nombreID = obj.objetoInput_.nombre + '-' + obj.objetoInput_.idInput;

                                        generarColumna = generarColumna + '<td ' + atributo + '><div class="input-group"><div class="input-group-prepend"><div class="input-group-text">' + obj.objetoInput_.monedaISO + '</div><input id = "' + nombreID + '"  name = "' + nombreID + '" value="' + obj.valorColumna + '" ' + obj.objetoInput_.atributo + '></div></div></td>';
                                    }
                                    else {
                                        var nombreID = obj.objetoInput_.nombre + '-' + obj.objetoInput_.idInput;
                                        generarColumna = generarColumna + '<td ' + atributo + '><input id = "' + nombreID + '"  name = "' + nombreID + '" value="' + obj.valorColumna + '" ' + obj.objetoInput_.atributo + '></td>';
                                    }
                                }
                                else if (obj.esSelect) {
                                    var opciones = "";
                                    var nombreSelect = obj.objetoSelect_.nombre + '-' + obj.objetoSelect_.idSelect;
                                    obj.objetoSelect_.valoresSelect_.forEach(function (objSelect) {
                                        if (objSelect.valSelect == 1) {
                                            opciones = opciones + '<option value="' + objSelect.valSelect + '" selected>' + objSelect.textSelect + '</option>';
                                        }
                                        else {
                                            opciones = opciones + '<option value="' + objSelect.valSelect + '">' + objSelect.textSelect + '</option>';
                                        }
                                    });
                                    generarColumna = generarColumna + '<td ' + atributo + '><select name="' + nombreSelect + '" ' + obj.objetoSelect_.atributo + ' value="1" >' + opciones + '</select></td>';

                                }
                                else {
                                    generarColumna = generarColumna + '<td ' + atributo + '>' + obj.valorColumna + '</td>';

                                }
                            }
                            else {
                                if (obj.objetoBtn_ != null) {
                                    var bool = false
                                    obj.objetoBtn_.forEach(function (val) {
                                        var temp = val.Class != null ? val.Class : '';
                                        if (temp.includes('hide')) { 
                                        bool = true
                                    }
                                    });

                                    generarColumna = bool ? generarColumna + '<td hidden>' : generarColumna + '<td>';
                                    obj.objetoBtn_.forEach(function (objBtn) {
                                        if (objBtn.Class != NaN || objBtn.Class != "") {
                                            var atributo = "";
                                            if (objBtn.atributo != NaN || objBtn.atributo != "") {
                                                atributo = objBtn.atributo;
                                            } else {
                                                atributo = "";
                                            }
                                            generarColumna = generarColumna + '<button class="btn ' + objBtn.Class + '" data-toggle="tooltip" data-placement="bottom" title="' + objBtn.tituloBtn + '" onclick="' + objBtn.funcionJs + '(\'' + objBtn.id + '\')"  ' + atributo + '><i class="' + objBtn.icono + '"></i></button>';
                                        }
                                        else {
                                            var atributo = "";
                                            if (objBtn.atributo != NaN || objBtn.atributo != "") {
                                                atributo = objBtn.atributo;
                                            } else {
                                                atributo = "";
                                            }
                                            generarColumna = generarColumna + '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="' + objBtn.tituloBtn + '" onclick="' + objBtn.funcionJs + '(\'' + objBtn.id + '\')"  ' + atributo + '><i class="' + objBtn.icono + '"></i></button>';
                                        }
                                    });

                                    nuevaFila = true;
                                } else {
                                    nuevaFila = true;
                                }
                            }
                        });

                        generarColumna = generarColumna + "</tr>";
                        $('#' + idFila).append(generarColumna);
                        if (paginacion === undefined) {
                            if (arrayNotOrder === undefined) {
                                $('#' + nombreTabla).DataTable({
                                    "order": [[0, "desc"]],
                                    "language": {
                                        "emptyTable": "No existen datos que mostrar."
                                    },
                                });
                            }
                            else {
                                $('#' + nombreTabla).DataTable({
                                    "columnDefs": [{
                                        "targets": arrayNotOrder,
                                        "orderSequence": false

                                    }],
                                    "language": {
                                        "emptyTable": "No existen datos que mostrar."
                                    },
                                    "order": [[0, "desc"]],
                                });
                            }
                        } else {
                            if (arrayNotOrder === undefined) {
                                $('#' + nombreTabla).DataTable({
                                    "order": [[0, "desc"]],
                                    "language": {
                                        "emptyTable": "No existen datos que mostrar."
                                    },
                                    "paging": false,
                                });
                            }
                            else {
                                $('#' + nombreTabla).DataTable({
                                    "columnDefs": [{
                                        "targets": arrayNotOrder,
                                        "orderSequence": false

                                    }],
                                    "language": {
                                        "emptyTable": "No existen datos que mostrar."
                                    },
                                    "order": [[0, "desc"]],
                                    "paging": false,
                                });
                            }
                        }
                        
                        try {
                            IniciarInputs();
                        } catch (e) {
                        }
                        return true;
                    } catch (e) {
                        $('#' + nombreTabla).empty();
                        swal("No existen datos que mostrar.", "", "info");
                        return false;
                    }

                }
                else {
                    swal("La sesión ha expirado.", "", "danger");
                    window.location.replace(rootPath + redirect);
                }
            }
        },
        error: function (data) {

            $("#wait-dialog").modal('hide');
            swal('Error al intentar recuerar los datos', 'error', 'error');
        }

    });
}

function mtRecuperarDatosTablaModal(varUrl, varData, redirect, nombreTabla, idFila) {
    if (varData == null) {
        varData = {};
    }
    var table = $('#' + nombreTabla).DataTable();
    var generarColumna = "";
    var nuevaFila = false;
    table.destroy();
    $.ajax({
        url: rootPath + varUrl,
        type: "POST",
        data: varData,
        success: function (data) {
            $("#wait-dialog").modal("hide");
            var sessionActiva = -1;
            try {
                sessionActiva = data.indexOf("SignIn?ReturnUrl");
            } catch (e) {
                sessionActiva = -1;
            }
            if (sessionActiva == -1) {
                try {
                    generarColumna = "<tr>"
                    data.forEach(function (obj) {
                        if (nuevaFila) {
                            generarColumna = generarColumna + "</tr><tr>";
                            nuevaFila = false;
                        }

                        if (!obj.esBtn) {

                            generarColumna = generarColumna + '<td>' + obj.valorColumna + '</td>';

                        }
                        else {
                            if (obj.objetoBtn_ != null) {
                                generarColumna = generarColumna + '<td>';
                                obj.objetoBtn_.forEach(function (objBtn) {
                                    if (objBtn.Class != NaN || objBtn.Class != "") {
                                        var atributo = "";
                                        if (objBtn.atributo != NaN || objBtn.atributo != "") {
                                            atributo = objBtn.atributo;
                                        } else {
                                            atributo = "";
                                        }
                                        generarColumna = generarColumna + '<button class="btn ' + objBtn.Class + '" data-toggle="tooltip" data-placement="bottom" title="' + objBtn.tituloBtn + '" onclick="' + objBtn.funcionJs + '(\'' + objBtn.id + '\')" ' + atributo + '><i class="' + objBtn.icono + '"></i></button>';
                                    }
                                    else {
                                        var atributo = "";
                                        if (objBtn.atributo != NaN || objBtn.atributo != "") {
                                            atributo = objBtn.atributo;
                                        } else {
                                            atributo = "";
                                        }
                                        generarColumna = generarColumna + '<button class="btn" data-toggle="tooltip" data-placement="bottom" title="' + objBtn.tituloBtn + '" onclick="' + objBtn.funcionJs + '(\'' + objBtn.id + '\')" ' + atributo + '><i class="' + objBtn.icono + '"></i></button>';
                                    }
                                });

                                nuevaFila = true;
                            }
                            else {
                                nuevaFila = true;
                            }
                        }
                    });
                    generarColumna = generarColumna + "</tr>";
                    $('#' + idFila).append(generarColumna);
                    return true;
                } catch (e) {
                    $('#' + nombreTabla).empty();
                    swal("No existen datos que mostrar.", "", "info");
                    return false;
                }
            }
            else {
                swal("La sesión ha expirado.", "", "danger");
                window.location.replace(rootPath + redirect);
            }
        }
    });
}

function descodificarEntidad(str) {
    return str.replace(/&#(\d+);/g, function (match, dec) {
        return String.fromCharCode(dec);
    });
}

function redirectURL(url) {
    window.location.href = url;
}

function encode_utf8(s) {
    return unescape(encodeURIComponent(s));
}

function decode_utf8(s) {
    return decodeURIComponent(escape(s));
}