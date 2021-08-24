using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EntregasEntity: EN

    {
        public EntregasEntity()
        {
            Provincia = Provincia ?? new CatalogoProvinciaEntity();
            Canton = Canton ?? new CatalogoCantonEntity();
            Distrito = Distrito ?? new CatalogoDistritoEntity();
        }

        public int? EntregaId  { get; set; }
        public DateTime FechaEntrega { get; set; } = DateTime.Now;
        public int? PedidoId { get; set; }
        public int? IdCatalogoProvincia { get; set; }
        public CatalogoProvinciaEntity Provincia { get; set; }
        public int? IdCatalogoCanton { get; set; }
        public CatalogoCantonEntity Canton { get; set; }
        public int? IdCatalogoDistrito { get; set; }
        public CatalogoDistritoEntity Distrito { get; set; }
        public int? CamionId { get; set; }


    }
}
