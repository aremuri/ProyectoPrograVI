using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;


namespace WBL
{
    public interface IConductorServices
    {
        Task<DBEntity> Create(ConductoresEntity entity);
        Task<DBEntity> Delete(ConductoresEntity entity);
        Task<IEnumerable<ConductoresEntity>> Get();
        Task<ConductoresEntity> GetById(ConductoresEntity entity);
        Task<IEnumerable<ConductoresEntity>> GetLista();
        Task<DBEntity> Update(ConductoresEntity entity);
    }

    public class ConductorServices : IConductorServices
    {
        private readonly IDataAccess sql;

        public ConductorServices(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<ConductoresEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ConductoresEntity>("ConductorObtener");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<ConductoresEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<ConductoresEntity>("ConductorLista");

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ConductoresEntity> GetById(ConductoresEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ConductoresEntity>("ConductorObtener", new
                {
                    entity.ConductorId
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Create(ConductoresEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ConductorInsertar", new
                {
                    entity.CedulaConductor,
                    entity.NombreConductor,
                    entity.TelefonoConductor,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Update(ConductoresEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ConductorActualizar", new
                {
                    entity.ConductorId,
                    entity.CedulaConductor,
                    entity.NombreConductor,
                    entity.TelefonoConductor,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(ConductoresEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ConductorEliminar", new
                {
                    entity.ConductorId
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
