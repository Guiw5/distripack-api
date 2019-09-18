using System;
using System.Collections.Generic;

namespace DistripackAPI.Controllers.ApiModels
{
    public class Order : ApiModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public ICollection<Item> Items { get; set; }

        public String State { get; set; }

        public int Discount { get; set; }

        public double PreviousBalance { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? DeliveredAt { get; set; }
    }
}
