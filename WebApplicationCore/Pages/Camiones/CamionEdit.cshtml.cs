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
    public class CamionEditModel : PageModel
    {
        private readonly ICamionesServices camionesServices;

        public CamionEditModel(ICamionesServices camionesServices)
        {
            this.camionesServices = camionesServices;
        }

        [BindProperty]
        [FromBody]
        public CamionesEntity Entity { get; set; } = new CamionesEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await camionesServices.GetById(new() { CamionId = id });
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

                if (Entity.CamionId.HasValue)
                {
                    //Actualizar 
                    result = await camionesServices.Update(Entity);
                }
                else
                {
                    //Nuevo 
                    result = await camionesServices.Create(Entity);
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
