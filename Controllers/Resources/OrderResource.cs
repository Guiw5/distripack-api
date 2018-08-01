using DistripackAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DistripackAPI.Controllers.Resources
{
    public class OrderResource
    {
        public OrderResource()
        {
            this.Items = new Collection<ItemResource>();
        }

        public int Id { get; set; }

        public int ClientId { get; set; }

        public ICollection<ItemResource> Items { get; set; }

        public double Subtotal { get; set; }

        public EstadoPedido State { get; set; }

        public String CreationDate { get; set; }

        public String CreationTime { get; set; }

        public String DeliveryDate { get; set; }

        public String DeliveryTime { get; set; }
    }

    public class ItemResource
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

    }
}
