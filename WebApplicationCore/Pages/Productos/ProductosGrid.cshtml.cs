using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplicationCore.Pages.Productos
{
    public class ProductosGridModel : PageModel
    {
        private readonly IProductosService productosService;

        public ProductosGridModel(IProductosService productosService )
        {
            this.productosService = productosService;
        }

        public IEnumerable<ProductosEntity> GridList { get; set; } = new List<ProductosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await productosService.Get();

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
                var result = await productosService.Delete(new()
                {
                    ProductoId = id

                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "Se eliminó correctamente";

                return Redirect("ProductosGrid");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }


    }
}
