using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApplicationCore.Pages.Pedidos
{
    public class PedidosEditModel : PageModel
    {
        private readonly IPedidosService pedidosService;
        private readonly ICatalogoProductosService catalogoProductosService;
        private readonly IClientesServices clientesPedidosService;

        public PedidosEditModel(IPedidosService pedidosService, ICatalogoProductosService catalogoProductosService, IClientesServices clientesPedidosService)
        {
            this.pedidosService = pedidosService;
            this.catalogoProductosService = catalogoProductosService;
            this.clientesPedidosService = clientesPedidosService;
        }

        [BindProperty]
        public PedidosEntity Entity { get; set; } = new PedidosEntity();

        public IEnumerable<CatalogoProductosEntity> CatalogoProductosLista { get; set; } = new List<CatalogoProductosEntity>();

        public IEnumerable<ClientesEntity> PedidosClientesLista { get; set; } = new List<ClientesEntity>();


        [BindProperty(SupportsGet = true)]

        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {

                    Entity = await pedidosService.GetById(new() { Codigo = id });
                }

                    CatalogoProductosLista = await catalogoProductosService.GetLista();
                PedidosClientesLista = await clientesPedidosService.Get();

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
                if (id.HasValue)
                {
                    //Actualizar 

                    var result = await pedidosService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El pedido fue actualizado";
                }
                else
                {
                    //Nuevo 
                    var result = await pedidosService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se agregó el pedido correctamente";

                }

                return RedirectToPage("PedidosGrid");
            }



            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
