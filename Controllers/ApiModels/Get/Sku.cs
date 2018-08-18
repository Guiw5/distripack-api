using System;

namespace DistripackAPI.Controllers.ApiModels.Get
{
    public class Sku
    {
        public Sku()
        {
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public String Code { get; set; }

        public String Nick { get; set; }

        public String Description { get; set; }

        public String Brand { get; set; }

        public String Color { get; set; }

        public int Quantity { get; set; }

        public Double Price { get; set; }

        public String Capacity { get; set; }

        public String Measures { get; set; }

        public String Material { get; set; }

    }
}
