using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels
{
    public class CreateItem : ApiModel
    {
        [Required]
        public int? SkuId { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public double? Price { get; set; }

    }
    public class UpdateItem : CreateItem
    {
        public int? Id { get; set; }
    }
}
