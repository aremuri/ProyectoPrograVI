"use strict";
var ClientesEdit;
(function (ClientesEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
        },
        methods: {
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando");
                    App.AxiosProvider.ClientesGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardó el registro", icon: "success" }).then(function () { return window.location.href = "Clientes/ClientesGrid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    });
                }
                else {
                    Toast.fire({ title: "Por favor complete los campos requeridos" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        },
    });
    Formulario.$mount("#AppEdit");
})(ClientesEdit || (ClientesEdit = {}));
//# sourceMappingURL=ClientesEdit.js.map