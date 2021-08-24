"use strict";
var ClientesGrid;
(function (ClientesGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp //Icono de Exitoso
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Clientes/ClientesGrid?handler=Eliminar&id=" + id;
            }
        });
    }
    ClientesGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(ClientesGrid || (ClientesGrid = {}));
//# sourceMappingURL=ClientesGrid.js.map