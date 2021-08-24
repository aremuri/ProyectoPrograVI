namespace ClientesGrid {


    declare var MensajeApp;

    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp//Icono de Exitoso
        });

    }

    export function OnClickEliminar(id) {

        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(result => {
                if (result.isConfirmed) {
                    window.location.href = "Clientes/ClientesGrid?handler=Eliminar&id=" + id;
                }

            });

    }

    $("#GridView").DataTable();


}