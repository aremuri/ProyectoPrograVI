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
    public class EntregaEditModel : PageModel
    {
        private readonly IEntregaServices entregaServices;
        private readonly ICatalogoProvinciaService catalogoProvinciaService;
        private readonly ICatalogoCantonService catalogoCantonService;
        private readonly ICatalogoDistritoService catalogoDistritoService;
        private readonly ICamionesServices camionesServices;
        private readonly IConductorServices conductorServices;

        public EntregaEditModel(IEntregaServices entregaServices, ICatalogoProvinciaService catalogoProvinciaService, ICatalogoCantonService catalogoCantonService, ICatalogoDistritoService catalogoDistritoService, ICamionesServices camionesServices, IConductorServices conductorServices)
        {
            this.entregaServices = entregaServices;
            this.catalogoProvinciaService = catalogoProvinciaService;
            this.catalogoCantonService = catalogoCantonService;
            this.catalogoDistritoService = catalogoDistritoService;
            this.camionesServices = camionesServices;
            this.conductorServices = conductorServices;
        }

        [BindProperty]
        [FromBody]


        public EntregasEntity Entity { get; set; } = new EntregasEntity();
        public IEnumerable<CatalogoProvinciaEntity> ProvinciaLista { get; set; } = new List<CatalogoProvinciaEntity>();

        public IEnumerable<CamionesEntity> CamionesLista { get; set; } = new List<CamionesEntity>();

        public IEnumerable<ConductoresEntity> ConductorLista { get; set; } = new List<ConductoresEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {
                    Entity = await entregaServices.GetById(new() { EntregaId = id });
                }

                ProvinciaLista = await catalogoProvinciaService.GetLista();
                CamionesLista = await camionesServices.GetLista();
                ConductorLista = await conductorServices.GetLista();

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
                if (Entity.EntregaId.HasValue)
                {
                    //Actualizar 
                    result = await entregaServices.Update(Entity);
                }
                else
                {
                    //Nuevo 
                    result = await entregaServices.Create(Entity);
                }

                return new JsonResult(result);
            }

            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

        public async Task<IActionResult> OnPostChangeProvincia()
        {

            try
            {
                var result = await catalogoCantonService.GetLista(
                      new CatalogoProvinciaEntity { IdCatalogoProvincia = Entity.IdCatalogoProvincia }
                    );
                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

        public async Task<IActionResult> OnPostChangeCanton()
        {

            try
            {
                var result = await catalogoDistritoService.GetLista(
                      new CatalogoCantonEntity { IdCatalogoCanton = Entity.IdCatalogoCanton }
                    );
                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }
    }
}
