namespace DistripackAPI.Models
{
    public class ProductCategory
    {
        public byte CategoryId { get; set; }

        public Category Category { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }


    }
}