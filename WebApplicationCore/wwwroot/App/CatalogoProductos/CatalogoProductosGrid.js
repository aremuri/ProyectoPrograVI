"use strict";
var CatalogoProductosGrid;
(function (CatalogoProductosGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "CatalogoProductos/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    CatalogoProductosGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(CatalogoProductosGrid || (CatalogoProductosGrid = {}));
//# sourceMappingURL=CatalogoProductosGrid.js.map