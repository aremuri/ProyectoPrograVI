using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WBL
{
    public interface IEntregaServices
    {
        Task<DBEntity> Create(EntregasEntity entity);
        Task<DBEntity> Delete(EntregasEntity entity);
        Task<IEnumerable<EntregasEntity>> Get();
        Task<EntregasEntity> GetById(EntregasEntity entity);
        Task<DBEntity> Update(EntregasEntity entity);
    }

    public class EntregaServices : IEntregaServices
    {
        private readonly IDataAccess sql;

        public EntregaServices(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<EntregasEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<EntregasEntity,
                    CatalogoProvinciaEntity,
                    CatalogoCantonEntity,
                    CatalogoDistritoEntity
                    >("EntregaObtener", "IdCatalogoProvincia,IdCatalogoCanton,IdCatalogoDistrito");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<IEnumerable<EntregasEntity>> GetLista()
        //{
        //    try
        //    {
        //        var result = sql.QueryAsync<EntregasEntity>("EntregaLista");

        //        return await result;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<EntregasEntity> GetById(EntregasEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<EntregasEntity>("EntregaObtener", new
                {
                    entity.EntregaId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> Create(EntregasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("EntregaInsertar", new
                {
                    entity.FechaEntrega,
                    entity.PedidoId,
                    entity.IdCatalogoProvincia,
                    entity.IdCatalogoCanton,
                    entity.IdCatalogoDistrito,
                    entity.CamionId,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(EntregasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("EntregaActualizar", new
                {
                    entity.EntregaId,
                    entity.FechaEntrega,
                    entity.PedidoId,
                    entity.IdCatalogoProvincia,
                    entity.IdCatalogoCanton,
                    entity.IdCatalogoDistrito,
                    entity.CamionId,
                    entity.Estado,
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(EntregasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("EntregaEliminar", new
                {
                    entity.EntregaId,
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
