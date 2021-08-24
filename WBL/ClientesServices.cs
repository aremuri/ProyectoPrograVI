using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IClientesServices
    {
        Task<DBEntity> Create(ClientesEntity entity);
        Task<DBEntity> Delete(ClientesEntity entity);
        Task<IEnumerable<ClientesEntity>> Get();
        Task<ClientesEntity> GetById(ClientesEntity entity);
        Task<DBEntity> Update(ClientesEntity entity);
    }

    public class ClientesServices : IClientesServices
    {
        private readonly IDataAccess sql;//propiedad de tipo privada

        public ClientesServices(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<ClientesEntity>> Get()//obtiene toda la lista
        {
            try
            {
                var result = sql.QueryAsync<ClientesEntity>("ClientesObtener");

                return await result;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<ClientesEntity> GetById(ClientesEntity entity)//Obtiene solo un dato de la lista
        {
            try
            {
                var result = sql.QueryFirstAsync<ClientesEntity>("ClientesObtener", new
                {
                    entity.IdCliente
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DBEntity> Create(ClientesEntity entity)//Ejecuta el metodo ExecuteAsync del DataAcces
        {
            try
            {
                var result = sql.ExecuteAsync("ClienteInsertar", new
                {
                    entity.Cedula,
                    entity.Nombre,
                    entity.Apellidos,
                    entity.Direccion,
                    entity.FechaNacimiento,
                    entity.Telefono,
                    entity.Estado

                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DBEntity> Update(ClientesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ClienteActualizar", new
                {
                    entity.IdCliente,
                    entity.Cedula,
                    entity.Nombre,
                    entity.Apellidos,
                    entity.Direccion,
                    entity.FechaNacimiento,
                    entity.Telefono,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DBEntity> Delete(ClientesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ClienteEliminar", new
                {
                    entity.IdCliente
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
