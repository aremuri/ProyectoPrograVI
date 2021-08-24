using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplicationCore.Pages.Pedidos
{
    public class PedidosGridModel : PageModel
    {
        private readonly IPedidosService pedidosService;

        public PedidosGridModel(IPedidosService pedidosService)
        {
            this.pedidosService = pedidosService;
        }

        public IEnumerable<PedidosEntity> GridList { get; set; } = new List<PedidosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await pedidosService.Get();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }

                TempData.Clear();

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
                var result = await pedidosService.Delete(new()
                {
                    Codigo = id

                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "Se elimino correctamente";

                return Redirect("PedidosGrid");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
