using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplicationCore.Pages.Camiones
{
    public class CamionGridModel : PageModel
    {
        private readonly ICamionesServices camionesServices;

        public CamionGridModel(ICamionesServices camionesServices)
        {
            this.camionesServices = camionesServices;
        }

        public IEnumerable<CamionesEntity> GridList { get; set; } = new List<CamionesEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
              
                GridList = await camionesServices.Get();

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
                var result = await camionesServices.Delete(new()
                {
                    CamionId = id
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
