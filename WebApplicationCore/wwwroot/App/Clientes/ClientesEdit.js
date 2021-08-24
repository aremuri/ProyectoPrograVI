"use strict";
var ClientesEdit;
(function (ClientesEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(ClientesEdit || (ClientesEdit = {}));
//# sourceMappingURL=ClientesEdit.js.map