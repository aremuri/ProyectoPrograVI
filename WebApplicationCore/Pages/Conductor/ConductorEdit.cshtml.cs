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
    public class ConductorEditModel : PageModel
    {
        private readonly IConductorServices conductorServices;

        public ConductorEditModel(IConductorServices conductorServices)
        {
            this.conductorServices = conductorServices;
        }

        [BindProperty]
        [FromBody]
        public ConductoresEntity Entity { get; set; } = new ConductoresEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await conductorServices.GetById(new() { ConductorId = id });
                }

                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();

                if (Entity.ConductorId.HasValue)
                {
                    //Actualizar 
                    result = await conductorServices.Update(Entity);
                }
                else
                {
                    //Nuevo 
                    result = await conductorServices.Create(Entity);
                }

                return new JsonResult(result);
            }



            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }
    }
}
