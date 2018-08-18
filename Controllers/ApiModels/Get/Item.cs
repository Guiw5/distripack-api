using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels.Get
{
    public class Item
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [Required]
        public int SkuId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        public double Discount { get; set; }

    }
}
