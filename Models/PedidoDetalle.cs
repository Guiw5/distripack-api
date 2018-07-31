using DistripackAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistriPack.Models
{
    public class PedidoDetalle
    {
        [Key]
        [Column(Order = 2)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        [ForeignKey("ProductoId, Sku")]
        public Producto Producto { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        public int Sku { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public Double PrecioUnitario { get; set; }

        public Double Descuento { get; set; }
    }
}