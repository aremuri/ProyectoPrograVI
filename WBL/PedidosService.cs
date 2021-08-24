using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IPedidosService
    {
        Task<DBEntity> Create(PedidosEntity entity);
        Task<DBEntity> Delete(PedidosEntity entity);
        Task<IEnumerable<PedidosEntity>> Get();
        Task<PedidosEntity> GetById(PedidosEntity entity);
        Task<IEnumerable<ClientesEntity>> GetListaClientes();
        Task<DBEntity> Update(PedidosEntity entity);
    }

    public class PedidosService : IPedidosService
    {
        private readonly IDataAccess sql;

        public PedidosService(IDataAccess _sql)
        {
            sql = _sql;
        }
        public async Task<IEnumerable<PedidosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<PedidosEntity>("PedidosObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<ClientesEntity>> GetListaClientes()
        {
            try
            {
                var result = sql.QueryAsync<ClientesEntity>("PedidosClientesLista");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<PedidosEntity> GetById(PedidosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<PedidosEntity>("PedidosObtener", new
                {
                    entity.Codigo
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DBEntity> Create(PedidosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PedidosInsertar", new
                {
                    entity.IdCliente,
                    entity.FechaPedido,
                    entity.CategoriaId,
                    entity.Cantidad,
                    entity.Subtotal,
                    entity.Envio,
                    entity.IVA,
                    entity.Total

                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DBEntity> Update(PedidosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PedidosActualizar", new
                {
                    entity.Codigo,
                    entity.IdCliente,
                    entity.FechaPedido,
                    entity.CategoriaId,
                    entity.Cantidad,
                    entity.Subtotal,
                    entity.Envio,
                    entity.IVA,
                    entity.Total
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DBEntity> Delete(PedidosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PedidosEliminar", new
                {
                    entity.Codigo
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
