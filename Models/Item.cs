using System;

namespace DistripackAPI.Models
{
    public class Item
    {
        public Item()
        {
            Discount = 0;
        }

        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public Sku Sku { get; set; }

        public int SkuId { get; set; }

        public int Quantity { get; set; }

        public Double UnitPrice { get; set; }

        public Double Discount { get; set; }

        public Double Subtotal => UnitPrice * Quantity * (100 - Discount) / 100;
    }
}