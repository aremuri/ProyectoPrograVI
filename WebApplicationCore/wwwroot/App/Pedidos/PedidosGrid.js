"use strict";
var PedidosGrid;
(function (PedidosGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Pedidos/PedidosGrid?handler=Eliminar&id=" + id;
            }
        });
    }
    PedidosGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(PedidosGrid || (PedidosGrid = {}));
//# sourceMappingURL=PedidosGrid.js.map