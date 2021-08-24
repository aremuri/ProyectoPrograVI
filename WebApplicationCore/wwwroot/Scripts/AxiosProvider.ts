
namespace App.AxiosProvider   {

    export const EntregaEliminar = (id) => axios.delete<DBEntity>("Entregas/EntregaGrid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const EntregaGuardar = (entity) => axios.post<DBEntity>("Entregas/EntregaEdit", entity).then(({ data }) => data);
    export const EntregaChangeProvincia = (entity) => axios.post<any[]>("Entregas/EntregaEdit?handler=ChangeProvincia", entity).then(({ data }) => data);
    export const EntregaChangeCanton = (entity) => axios.post<any[]>("Entregas/EntregaEdit?handler=ChangeCanton", entity).then(({ data }) => data);

    export const PedidosChangeCategoria = (entity) => axios.post<any[]>("Pedidos/PedidosEdit?handler=ChangeCategoria", entity).then(({ data }) => data);
   // export const PedidosChangeProducto = (entity) => axios.post<any[]>("Pedidos/PedidosEdit?handler=ChangeProducto", entity).then(({ data }) => data);
    export const PedidosGuardar = (entity) => axios.post<DBEntity>("Pedidos/PedidosEdit", entity).then(({ data }) => data);

    export const CamionEliminar = (id) => axios.delete<DBEntity>("Camiones/CamionGrid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const CamionGuardar = (entity) => axios.post<DBEntity>("Camiones/CamionEdit", entity).then(({ data }) => data);
    
}




