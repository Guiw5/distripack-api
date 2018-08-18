using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels.Post
{
    public class Order
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public ICollection<Item> Items { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeliveryDate { get; set; }
    }
}
