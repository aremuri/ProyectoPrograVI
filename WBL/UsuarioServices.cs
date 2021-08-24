using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IUsuarioServices
    {
        Task<UsuariosEntity> Login(UsuariosEntity entity);
        Task<DBEntity> Registrar(UsuariosEntity entity);
    }

    public class UsuarioServices : IUsuarioServices
    {
        private readonly IDataAccess sql;

        public UsuarioServices(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<UsuariosEntity> Login(UsuariosEntity entity)//obtiene toda la lista
        {
            try
            {
                var result = sql.QueryFirstAsync<UsuariosEntity>("Login", new
                {

                    entity.Usuario,
                    entity.Contrasena,

                });

                return await result;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DBEntity> Registrar(UsuariosEntity entity)//Ejecuta el metodo ExecuteAsync del DataAcces
        {
            try
            {
                var result = sql.ExecuteAsync("UsuarioRegistrar", new
                {
                    entity.Usuario,
                    entity.Nombre,
                    entity.Contrasena

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
