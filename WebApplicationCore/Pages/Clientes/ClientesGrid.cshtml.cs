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

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await clientesServices.Get();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }

                TempData.Clear();//limpia el mensaje q se aparece

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await clientesServices.Delete(new()
                {
                    IdCliente = id

                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "Se elimino correctamente";

                return Redirect("ClientesGrid");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
