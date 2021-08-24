"use strict";
var EntregaEdit;
(function (EntregaEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
            CantonLista: [],
            DistritoLista: [],
        },
        methods: {
            OnChangeProvincia: function () {
                var _this = this;
                Loading.fire("Cargando..");
                App.AxiosProvider.EntregaChangeProvincia(this.Entity).then(function (data) {
                    Loading.close();
                    _this.CantonLista = data;
                });
            },
            OnChangeCanton: function () {
                var _this = this;
                Loading.fire("Cargando..");
                App.AxiosProvider.EntregaChangeCanton(this.Entity).then(function (data) {
                    Loading.close();
                    _this.DistritoLista = data;
                });
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando");
                    App.AxiosProvider.EntregaGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardó el registro", icon: "success" }).then(function () { return window.location.href = "Entregas/EntregaGrid"; });
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
        created: function () {
            this.OnChangeProvincia();
            this.OnChangeCanton();
        }
    });
    Formulario.$mount("#AppEdit");
})(EntregaEdit || (EntregaEdit = {}));
//# sourceMappingURL=EntregaEdit.js.map