using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels
{
    public class CreateOrder : ApiModel
    {
        [Required]
        public int? ClientId { get; set; }

        [Required]
        public ICollection<CreateItem> Items { get; set; }

        public DateTime? CreatedAt { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        public double? PreviousBalance { get; set; }

        [Required]
        public int Discount { get; set; }

    }
}
