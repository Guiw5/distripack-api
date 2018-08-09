using System;

namespace DistripackAPI.Models
{
    public class Sku
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public String Code => "COD" + $"{ProductId + Id,10:D5}";

        public String Nick { get; set; }

        public String Description { get; set; }

        public String Brand { get; set; }

        public String Color { get; set; }

        public int Quantity { get; set; }

        public Double Price { get; set; }

        public String Capacity { get; set; }

        public String Measures { get; set; }

        public String Material { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }


    }
}
