using DistripackAPI.Controllers.ApiModels;
using System;

namespace DistripackAPI.Models
{
    public class Item : Entity
    {


        public Item(Order order, CreateItem i)
            : this(order, i.SkuId, i.Price, i.Quantity, 0)
        {

        }

        public Item(Order order, int skuId, Double price, int quantity, Double discount)
        {
            Order = order;
            OrderId = order.Id;
            SkuId = skuId;
            UnitPrice = price;
            Quantity = quantity;
            Discount = discount;
        }

        public Item()
        {
            Discount = 0;
        }

        public int OrderId { get; private set; }

        public Order Order { get; private set; }

        public Sku Sku { get; private set; }

        public int SkuId { get; private set; }

        public int Quantity { get; private set; }

        public Double UnitPrice { get; private set; }

        public Double Discount { get; private set; }

        public Double Subtotal => UnitPrice * Quantity * (100 - Discount) / 100;

        public void Update(double price, int quantity, Double discount = 0)
        {
            UnitPrice = price;
            Quantity = quantity;
            Discount = discount;

        }
    }
}