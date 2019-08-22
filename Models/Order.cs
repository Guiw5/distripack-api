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
            : this(apiOrder.ClientId.Value, apiOrder.Items, apiOrder.DeliveryDate, apiOrder.CreatedAt)
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
            //si todos los items nuevos son distintos al item de la ordenDb -> se eliminó
            var delete = Items.Where(itemDb => order.Items.All(i => i.Id.HasValue && i.Id.Value != itemDb.Id)).ToList();

            foreach (var item in delete)
                Delete(item);

            foreach (var item in order.Items)
            {
                if (item.Id.HasValue)
                    Update(item);
                else
                    Add(item);
            }

            //UpdateAt = DateTime.Now;
            Discount = 0;
            DeliveryDate = order.DeliveryDate;
        }

        private void Delete(Item i)
        {
            Items.Remove(i);
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
            Add(i.SkuId.Value, i.Price.Value, i.Quantity.Value);
        }

        public void Update(UpdateItem item)
        {
            Update(item.Id.Value, item.Price.Value, item.Quantity.Value);
        }

        private void Add(int skuId, double price, int quantity, Double discount = 0)
        {
            Items.Add(new Item(Id, skuId, price, quantity, discount));
        }

        private void Update(int id, double price, int quantity, Double discount = 0)
        {
            var item = Items.SingleOrDefault(i => i.Id == id);

            if (item == null)
                throw new Exception($"El item {id} que intenta modificar no se encuentra en la orden {Id}");

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