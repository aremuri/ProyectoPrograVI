using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductosEntity : EN
    {
        public ProductosEntity()
        {
            CatalogoProductos = CatalogoProductos ?? new CatalogoProductosEntity();
        }

        public int? ProductoId { get; set; }
        public int? CategoriaId { get; set; }
        public virtual CatalogoProductosEntity CatalogoProductos { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Caracteristicas { get; set; }
        public float Precio { get; set; }

    }
}
