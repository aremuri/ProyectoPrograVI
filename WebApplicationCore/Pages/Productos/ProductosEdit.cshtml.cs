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
    public class ProductosEditModel : PageModel
    {
        private readonly IProductosService productosService;
        private readonly ICatalogoProductosService catalogoProductosService;

        public ProductosEditModel(IProductosService productosService, ICatalogoProductosService catalogoProductosService)
        {
            this.productosService = productosService;
            this.catalogoProductosService = catalogoProductosService;

        }

        [BindProperty]
        public ProductosEntity Entity { get; set; } = new ProductosEntity();

        public IEnumerable<CatalogoProductosEntity> CatalogoProductosLista { get; set; } = new List<CatalogoProductosEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {
                    Entity = await productosService.GetById(new() { ProductoId = id });
                }

                CatalogoProductosLista = await catalogoProductosService.GetLista();

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
                if (Entity.ProductoId.HasValue)
                {
                    //Actualizar 
                    var result = await productosService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizó correctamente";
                }
                else
                {
                    //Nuevo 
                    var result = await productosService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se agregó correctamente";

                }

                return RedirectToPage("ProductosGrid");
            }



            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }



    }
}
