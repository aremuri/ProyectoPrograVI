using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ICatalogoProductosService
    {
        Task<DBEntity> Create(CatalogoProductosEntity entity);
        Task<DBEntity> Delete(CatalogoProductosEntity entity);
        Task<IEnumerable<CatalogoProductosEntity>> Get();
        Task<CatalogoProductosEntity> GetById(CatalogoProductosEntity entity);
        Task<IEnumerable<CatalogoProductosEntity>> GetLista();
        Task<DBEntity> Update(CatalogoProductosEntity entity);
    }

    public class CatalogoProductosService : ICatalogoProductosService
    {
        private readonly IDataAccess sql;

        public CatalogoProductosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<CatalogoProductosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<CatalogoProductosEntity>("CatalogoProductosObtener");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CatalogoProductosEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<CatalogoProductosEntity>("CatalogoProductosLista");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<CatalogoProductosEntity> GetById(CatalogoProductosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<CatalogoProductosEntity>("CatalogoProductosObtener", new
                {
                    entity.CategoriaId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Create(CatalogoProductosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CatalogoProductosInsertar", new
                {
                    entity.NombreCategoria,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Update(CatalogoProductosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CatalogoProductosActualizar", new
                {
                    entity.CategoriaId,
                    entity.NombreCategoria,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(CatalogoProductosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CatalogoProductosEliminar", new
                {
                    entity.CategoriaId
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
