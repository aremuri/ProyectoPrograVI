using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplicationCore.Pages.Clientes
{
    public class ClientesGridModel : PageModel
    {
        private readonly IClientesServices clientesServices;

        public ClientesGridModel(IClientesServices clientesServices)
        {
            this.clientesServices = clientesServices;//Variable que me permite jalar los metodos
        }

        public IEnumerable<ClientesEntity> GridList { get; set; } = new List<ClientesEntity>();//Propiedad IEnumerable


        public async Task<IActionResult> OnGet()
        {
            try
            {

                GridList = await clientesServices.Get();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<JsonResult> OnDeleteEliminar(int id)
        {
            try
            {
                var result = await clientesServices.Delete(new()
                {
                    IdCliente = id
                });

                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }
    }
}
