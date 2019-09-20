using DistripackAPI.Controllers.ApiModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DistripackAPI.Models
{
    public class Order
    {

        public Order(CreateOrder apiOrder)
            : this(apiOrder.ClientId.Value, apiOrder.Items, apiOrder.PreviousBalance, apiOrder.Discount, apiOrder.DeliveryDate, apiOrder.CreatedAt)
        { }

        public Order(int clientId, ICollection<CreateItem> items, double previousBalance, int discount, DateTime? deliveryDate, DateTime? createdAt = null)
        {
            ClientId = clientId;
            DeliveryDate = deliveryDate;
            UpdatedAt = DateTime.Now;
            CreatedAt = createdAt ?? UpdatedAt;
            State = OrderState.Created;
            Items = items.Select(i => new Item(this, i)).ToList();
            Discount = discount;
            PreviousBalance = previousBalance;
        }

        public Order()
        {
            Items = new Collection<Item>();
        }

        public int Id { get; set; }

        public Client Client { get; private set; }

        public int ClientId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public DateTime? DeliveryDate { get; private set; }

        public DateTime? DeliveredAt { get; private set; }

        public OrderState State { get; private set; }

        public ICollection<Item> Items { get; }

        //[0-100] i.e: 20% => 20
        public int Discount { get; private set; }

        public double PreviousBalance { get; private set; }

        public Double Subtotal => Items.Sum(x => x.Subtotal) * (100 - Discount) / 100;

        public Double Total => Subtotal + PreviousBalance;

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

            UpdatedAt = DateTime.Now;
            DeliveryDate = order.DeliveryDate;
            if (order.Discount.HasValue) Discount = order.Discount.Value;
            if (order.PreviousBalance.HasValue) PreviousBalance = order.PreviousBalance.Value;

        }

        private void Delete(Item i)
        {
            Items.Remove(i);
        }

        internal void Print()
        {
            if (OrderState.Printed < State)
                throw new Exception($"La orden { Id } ya se encuentra impresa");

            State = OrderState.Printed;
        }

        internal Transaction Deliver(DateTime? deliveryDate = null)
        {
            if (OrderState.Printed.Equals(State) || OrderState.InDelivery.Equals(State))
            {
                State = OrderState.Delivered;
                DeliveredAt = deliveryDate ?? DateTime.Now;
            }
            else
                throw new Exception($"La orden { Id } ya se encuentra entregada");

            return Client.AddReceipt(this);
        }

        public void Add(CreateItem i)
        {
            Add(i.SkuId.Value, i.Price.Value, i.Quantity.Value);
        }

        public void Update(UpdateItem item)
        {
            Update(item.Id.Value, item.Price.Value, item.Quantity.Value);
        }

        private void Add(int skuId, double price, int quantity, int discount = 0)
        {
            Items.Add(new Item(Id, skuId, price, quantity, discount));
        }

        private void Update(int id, double price, int quantity, int discount = 0)
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