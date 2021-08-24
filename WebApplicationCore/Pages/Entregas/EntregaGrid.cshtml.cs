using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;
namespace WebApplicationCore.Pages.Entregas
{
    public class EntregaGridModel : PageModel
    {
        private readonly IEntregaServices entregaServices;

        public EntregaGridModel(IEntregaServices entregaServices)
        {
            this.entregaServices = entregaServices;
        }

        public IEnumerable<EntregasEntity> GridList { get; set; } = new List<EntregasEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await entregaServices.Get();

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
                    var result = await entregaServices.Delete(new()
                    {

                        EntregaId = id
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
