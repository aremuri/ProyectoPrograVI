"use strict";
var CamionEdit;
(function (CamionEdit) {
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
                    App.AxiosProvider.CamionGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardó el registro", icon: "success" }).then(function () { return window.location.href = "Camiones/CamionGrid"; });
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
})(CamionEdit || (CamionEdit = {}));
//# sourceMappingURL=CamionEdit.js.map