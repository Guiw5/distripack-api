using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels.Post
{
    public class Item
    {
        [Required]
        public int SkuId { get; set; }

        public string SkuNick { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

    }
}
