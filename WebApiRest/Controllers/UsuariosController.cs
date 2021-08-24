using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
using Entity;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServices usuarioServices;

        public UsuariosController(IUsuarioServices usuarioServices )
        {
            this.usuarioServices = usuarioServices;
        }
                
        [HttpPost ("Login")]

        public async Task<UsuariosEntity> Login(UsuariosEntity entity) //es un POST para hacer el consumo del metodo de login
        {
            try
            {
                return await usuarioServices.Login(entity);
            }
            catch (Exception ex)
            {
                return new UsuariosEntity() { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }

        [HttpPost("Registrar")]

        public async Task<DBEntity> Registrar(UsuariosEntity entity) //es un POST para hacer el consumo del metodo de login
        {
            try
            {
                return await usuarioServices.Registrar(entity);
            }
            catch (Exception ex)
            {
                return new UsuariosEntity() { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }

    }
}
