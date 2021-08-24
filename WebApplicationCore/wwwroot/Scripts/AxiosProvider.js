"use strict";
var App;
(function (App) {
    var AxiosProvider;
    (function (AxiosProvider) {
        AxiosProvider.EntregaEliminar = function (id) { return axios.delete("Entregas/EntregaGrid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.EntregaGuardar = function (entity) { return axios.post("Entregas/EntregaEdit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.EntregaChangeProvincia = function (entity) { return axios.post("Entregas/EntregaEdit?handler=ChangeProvincia", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.EntregaChangeCanton = function (entity) { return axios.post("Entregas/EntregaEdit?handler=ChangeCanton", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.PedidosChangeCategoria = function (entity) { return axios.post("Pedidos/PedidosEdit?handler=ChangeCategoria", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        // export const PedidosChangeProducto = (entity) => axios.post<any[]>("Pedidos/PedidosEdit?handler=ChangeProducto", entity).then(({ data }) => data);
        AxiosProvider.PedidosGuardar = function (entity) { return axios.post("Pedidos/PedidosEdit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map