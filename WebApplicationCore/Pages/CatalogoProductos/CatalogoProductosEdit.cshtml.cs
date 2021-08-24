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
    public class CatalogoProductosEditModel : PageModel
    {
        private readonly ICatalogoProductosService catalogoProductosService;

        public CatalogoProductosEditModel(ICatalogoProductosService catalogoProductosService )
        {
            this.catalogoProductosService = catalogoProductosService;
        }

        [BindProperty]
        public CatalogoProductosEntity Entity{ get; set; } = new CatalogoProductosEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {
                    Entity = await catalogoProductosService.GetById(new() {CategoriaId = id });
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
                if (Entity.CategoriaId.HasValue)
                {
                    //Actualizar 
                    var result = await catalogoProductosService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizó correctamente";
                }
                else
                {
                    //Nuevo 
                    var result = await catalogoProductosService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se agregó correctamente";

                }

                return RedirectToPage("CatalogoProductosGrid");
            }



            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

    }
}
