using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DistripackAPI.Models
{
    public class Order
    {
        public Order()
        {
            Items = new Collection<Item>();
        }


        public int Id { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? DeliveredAt { get; set; }

        public OrderState State { get; set; }

        public ICollection<Item> Items { get; set; }

        public Double Subtotal => Items.Sum(x => x.Subtotal);

        public Double Discount { get; set; }
    }
}