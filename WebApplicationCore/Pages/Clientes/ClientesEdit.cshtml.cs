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
    public class ClientesEditModel : PageModel
    {
        private readonly IClientesServices clientesServices;

        public ClientesEditModel(IClientesServices clientesServices)
        {
            this.clientesServices = clientesServices;
        }

        [BindProperty]
        [FromBody]
        public ClientesEntity Entity { get; set; } = new ClientesEntity();

        [BindProperty(SupportsGet = true)]

        public int? id { get; set; }//valida si el Id viene vacio

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await clientesServices.GetById(new() { IdCliente = id });
                }

                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();

                if (Entity.IdCliente.HasValue)
                {
                    //Actualizar 
                    result = await clientesServices.Update(Entity);
                }
                else
                {
                    //Nuevo 
                    result = await clientesServices.Create(Entity);
                }

                return new JsonResult(result);
            }



            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

    }
}
