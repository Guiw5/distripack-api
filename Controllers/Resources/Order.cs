using DistripackAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.Resources
{
    public class Order
    {
        public Order()
        {
            this.Items = new Collection<Item>();
        }

        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public ICollection<Item> Items { get; set; }

        [Required]
        public double Subtotal { get; set; }

        public EstadoPedido State { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? DeliveryDate { get; set; }
    }

    public class Item
    {
        public int id { get; set; }

        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

    }
}
