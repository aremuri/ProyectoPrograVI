using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PedidosEntity :EN
    {
        public PedidosEntity()
        {
            CatalogoProductos = CatalogoProductos ?? new CatalogoProductosEntity();
            Producto = Producto ?? new ProductosEntity();
            NombreProducto = NombreProducto ?? new ProductosEntity();
            NombreCliente = NombreCliente ?? new ClientesEntity();
        }

        public int? Codigo { get; set; }
        public int? IdCliente { get; set; }
        public virtual ClientesEntity NombreCliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public int? CategoriaId { get; set; }
        public virtual CatalogoProductosEntity CatalogoProductos { get; set; }
        public int? ProductoId { get; set; }
        public virtual ProductosEntity Producto { get; set; }
        public string Nombre { get; set; }
        public virtual ProductosEntity NombreProducto { get; set; }
        public int? Cantidad { get; set; }
        public float Subtotal { get; set; }
        public float Envio { get; set; }
        public float IVA { get; set; }
        public float Total { get; set; }
    }
}
