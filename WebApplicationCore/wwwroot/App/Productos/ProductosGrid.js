"use strict";
var ProductosGrid;
(function (ProductosGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Productos/ProductosGrid?handler=Eliminar&id=" + id;
            }
        });
    }
    ProductosGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(ProductosGrid || (ProductosGrid = {}));
//# sourceMappingURL=ProductosGrid.js.map