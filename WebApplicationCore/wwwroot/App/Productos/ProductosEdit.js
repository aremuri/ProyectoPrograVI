"use strict";
var ProductosEdit;
(function (ProductosEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(ProductosEdit || (ProductosEdit = {}));
//# sourceMappingURL=ProductosEdit.js.map