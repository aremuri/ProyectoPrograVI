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
        public ClientesEntity Entity { get; set; } = new ClientesEntity();

        [BindProperty(SupportsGet = true)]

        public int? id { get; set; }//valida si el Id viene vacio

        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)//si tiene valor necesita editar
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

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                if (Entity.IdCliente.HasValue)//Validamos la entidad
                {
                    //Actualizar 
                    var result = await clientesServices.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizó correctamente";
                }
                else
                {
                    //Nuevo 
                    var result = await clientesServices.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se agregó correctamente";

                }

                return RedirectToPage("ClientesGrid");
            }



            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

    }
}
