using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplicationCore.Pages.Conductor
{
    public class ConductorGridModel : PageModel
    {
        private readonly IConductorServices conductorServices;

        public ConductorGridModel(IConductorServices conductorServices)
        {
            this.conductorServices = conductorServices;
        }

        public IEnumerable<ConductoresEntity> GridList { get; set; } = new List<ConductoresEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {

                GridList = await conductorServices.Get();

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
                var result = await conductorServices.Delete(new()
                {
                    ConductorId = id
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
