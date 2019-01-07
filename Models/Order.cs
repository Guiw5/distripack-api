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
            Discount = 0;
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

        public ICollection<Item> Items { get; }

        public Double Discount { get; private set; }

        public Double Subtotal => Items.Sum(x => x.Subtotal);

        public void Modify(UpdateOrder order)
        {
            var delete = Items.Where(itemDb => order.Items.All(i => i.SkuId != itemDb.SkuId)).ToList();

            foreach (var i in delete)
                Items.Remove(i);

            foreach (var i in order.Items)
            {
                var item = Items.SingleOrDefault(it => it.SkuId == i.SkuId);
                if (item == null)
                    Add(i);
                else
                    Update(i);
            }

            //UpdateAt = DateTime.Now;
            Discount = 0;
            DeliveryDate = order.DeliveryDate;
        }

        internal void Print()
        {
            if (OrderState.Printed < State)
                throw new Exception($"La orden {this.Id} ya se encuentra impresa");

            State = OrderState.Printed;
        }

        internal void Deliver(DateTime? deliveryDate = null)
        {
            if (OrderState.Printed.Equals(State) || OrderState.InDelivery.Equals(State))
            {
                State = OrderState.Delivered;
                DeliveredAt = deliveryDate ?? DateTime.Now;
            }
            else
                throw new Exception($"La orden {this.Id} ya se encuentra entregada");
        }

        public void Add(CreateItem i)
        {
            Add(i.SkuId, i.Price, i.Quantity);
        }

        public void Update(UpdateItem item)
        {
            Update(item.SkuId, item.Price, item.Quantity);
        }

        private void Add(int skuId, double price, int quantity, Double discount = 0)
        {
            if (Items.Any(i => i.SkuId == skuId))
                throw new Exception($"El item {skuId} que intenta agregar ya se encuentra en la orden {Id}");

            Items.Add(new Item(Id, skuId, price, quantity, discount));
        }

        private void Update(int skuId, double price, int quantity, Double discount = 0)
        {
            var item = Items.SingleOrDefault(i => i.SkuId == skuId);

            if (item == null)
                throw new Exception($"El item {skuId} que intenta modificar no se encuentra en la orden {Id}");

            item.Update(price, quantity, discount);
        }

        internal void Delete()
        {
            if (OrderState.Delivered.Equals(State))
                throw new Exception($"No se puede anular la orden {Id} ya se encuentra entregada");

            State = OrderState.Cancelled;
        }
    }
}