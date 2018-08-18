using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels.Post
{
    public class Item
    {
        [Required]
        public int SkuId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

    }
}
