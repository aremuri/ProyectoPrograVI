"use strict";
var CatalogoProductosEdit;
(function (CatalogoProductosEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(CatalogoProductosEdit || (CatalogoProductosEdit = {}));
//# sourceMappingURL=CatalogoProductosEdit.js.map