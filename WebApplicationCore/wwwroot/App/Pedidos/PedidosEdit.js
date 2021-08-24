"use strict";
var PedidossEdit;
(function (PedidossEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
            ProductosLista: [],
        },
        methods: {
            OnChangeCategoria: function () {
                var _this = this;
                Loading.fire("Cargando..");
                App.AxiosProvider.PedidosChangeCategoria(this.Entity).then(function (data) {
                    Loading.close();
                    _this.ProductosLista = data;
                });
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando");
                    App.AxiosProvider.PedidosGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardó el pedido", icon: "success" }).then(function () { return window.location.href = "Agencia/Grid"; });
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
            this.OnChangeCategoria();
        }
    });
    Formulario.$mount("#AppEdit");
})(PedidossEdit || (PedidossEdit = {}));
//# sourceMappingURL=PedidosEdit.js.map