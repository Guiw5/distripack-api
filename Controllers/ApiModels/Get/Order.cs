using DistripackAPI.Models;
using System;
using System.Collections.Generic;

namespace DistripackAPI.Controllers.ApiModels.Get
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public ICollection<Item> Items { get; set; }

        public double Subtotal { get; set; }

        public OrderState State { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? DeliveredAt { get; set; }
    }
}
