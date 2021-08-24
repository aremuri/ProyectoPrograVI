"use strict";
var CamionGrid;
(function (CamionGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando");
                App.AxiosProvider.CamionEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "Se eliminó correctamente", icon: "success" }).then(function () { return window.location.reload(); });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    CamionGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(CamionGrid || (CamionGrid = {}));
//# sourceMappingURL=CamionGrid.js.map