using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DistripackAPI.Models
{
    public class Pedido
    {
        public Pedido()
        {
            Detalles = new Collection<Detalle>();
        }


        public int Id { get; set; }

        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public EstadoPedido Estado { get; set; }

        public ICollection<Detalle> Detalles { get; set; }

        public Double Subtotal => Detalles.Sum(x => x.Subtotal);

        public Double Descuento { get; set; }
    }
}