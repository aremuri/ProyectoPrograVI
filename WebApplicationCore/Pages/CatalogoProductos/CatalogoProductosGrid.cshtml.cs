using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplicationCore.Pages.CatalogoProductos
{
    public class CatalogoProductosGridModel : PageModel
    {
        private readonly ICatalogoProductosService catalogoProductosService;

        public CatalogoProductosGridModel(ICatalogoProductosService catalogoProductosService)
        {
            this.catalogoProductosService = catalogoProductosService;
        }

        public IEnumerable<CatalogoProductosEntity> GridList { get; set; } = new List<CatalogoProductosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await catalogoProductosService.Get();

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
                var result = await catalogoProductosService.Delete(new()
                {
                    CategoriaId = id

                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "Se elimino correctamente";

                return Redirect("CatalogoProductosGrid");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
