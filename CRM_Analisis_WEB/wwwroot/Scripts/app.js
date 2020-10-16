var waitDialog = function () {
    $("#wait-dialog").modal({ backdrop: 'static', keyboard: false });
    $("#wait-dialog").modal("show");
}

var closeWaitDialog = function () {
    $("#wait-dialog").modal("hide");
}


