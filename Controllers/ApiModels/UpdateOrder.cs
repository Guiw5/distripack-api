using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels
{
    public class UpdateOrder
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public ICollection<CreateItem> Items { get; set; }

        public DateTime? DeliveryDate { get; set; }
    }
}
