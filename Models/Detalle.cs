using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistripackAPI.Models
{
    public class Detalle
    {

        public int Id { get; set; }

        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        [ForeignKey("ProductoId, ProductoSku")]
        public Producto Producto { get; set; }

        public int ProductoId { get; set; }

        public int ProductoSku { get; set; }

        public int Cantidad { get; set; }

        public Double PrecioUnitario { get; set; }

        public Double Descuento { get; set; }

        public Double Subtotal => PrecioUnitario * Cantidad * (100 - Descuento) / 100;
    }
}