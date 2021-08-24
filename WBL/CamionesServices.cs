using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ICamionesServices
    {
        Task<DBEntity> Create(CamionesEntity entity);
        Task<DBEntity> Delete(CamionesEntity entity);
        Task<IEnumerable<CamionesEntity>> Get();
        Task<CamionesEntity> GetById(CamionesEntity entity);
        Task<IEnumerable<CamionesEntity>> GetLista();
        Task<DBEntity> Update(CamionesEntity entity);
    }

    public class CamionesServices : ICamionesServices
    {
        private readonly IDataAccess sql;

        public CamionesServices(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<CamionesEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<CamionesEntity>("CamionObtener");

                return await result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CamionesEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<CamionesEntity>("CamionLista");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CamionesEntity> GetById(CamionesEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<CamionesEntity>("CamionObtener", new
                {
                    entity.CamionId
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Create(CamionesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CamionInsertar", new
                {
                    entity.Cualidad,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<DBEntity> Update(CamionesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CamionActualizar", new
                {
                    entity.CamionId,
                    entity.Cualidad,
                    entity.Estado,
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(CamionesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CamionEliminar", new
                {
                    entity.CamionId
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
