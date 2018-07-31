using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DistriPack.Models
{
    public class Pedido
    {
        public Pedido()
        {
            Detalles = new Collection<PedidoDetalle>();
        }
        public int Id { get; set; }

        public Cliente Cliente { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaEntrega { get; set; }

        [Required]
        public EstadoPedido Estado { get; set; }

        [Required]
        public ICollection<PedidoDetalle> Detalles { get; set; }

        public Double PrecioTotal { get; set; }

        public Double Descuento { get; set; }
    }
}