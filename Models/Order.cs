using DistripackAPI.Controllers.ApiModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DistripackAPI.Models
{
    public class Order : Entity
    {

        public Order(CreateOrder apiOrder)
            : this(apiOrder.ClientId, apiOrder.Items, apiOrder.DeliveryDate, apiOrder.CreatedAt)
        { }

        public Order(int clientId, ICollection<CreateItem> items, DateTime? deliveryDate, DateTime? createdAt = null)
        {
            ClientId = clientId;
            DeliveryDate = deliveryDate;
            CreatedAt = createdAt ?? DateTime.Now;
            State = OrderState.Created;
            Items = items.Select(i => new Item(this, i)).ToList();
        }

        public Order()
        {
            Items = new Collection<Item>();
        }

        public Client Client { get; private set; }

        public int ClientId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        //public DateTime? UpdateAt { get; private set; }

        public DateTime? DeliveryDate { get; private set; }

        public DateTime? DeliveredAt { get; private set; }

        public OrderState State { get; private set; }

        public ICollection<Item> Items { get; private set; }

        public Double Discount { get; private set; }

        public Double Subtotal => Items.Sum(x => x.Subtotal);

        public void AddItem(int skuId, double price, int quantity, Double discount = 0)
        {
            if (Items.Any(i => i.SkuId == skuId))
                throw new Exception($"El item {skuId} que intenta agregar ya se encuentra en la orden {Id}");

            Items.Add(new Item(this, skuId, price, quantity, discount));
        }

        internal void Update(ICollection<CreateItem> items, DateTime? deliveryDate = null)
        {
            var delete = new List<Item>();
            foreach (var itemDb in Items)
                if (items.All(i => i.SkuId != itemDb.SkuId))
                    delete.Add(itemDb);

            foreach (var i in delete)
                Items.Remove(i);

            foreach (var i in items)
                Update(i.SkuId, i.Price, i.Quantity);

            //UpdateAt = DateTime.Now;
            DeliveryDate = deliveryDate ?? DeliveryDate;
        }

        public void Update(int skuId, double price, int quantity, Double discount = 0)
        {
            var item = Items.SingleOrDefault(i => i.SkuId == skuId);
            //    throw new Exception($"El item {skuId} que intenta modificar no se encuentra en la orden {Id}");
            if (item == null)
                AddItem(skuId, price, quantity, discount);
            else
                item.Update(price, quantity, discount);
        }

        public void Print()
        {
            if (OrderState.Created.Equals(this.State))
                this.State = OrderState.Printed;
            else
                throw new Exception($"La orden {this.Id} ya se encuentra impresa");
        }
    }
}