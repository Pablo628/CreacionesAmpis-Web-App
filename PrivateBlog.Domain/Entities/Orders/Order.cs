using System;
using System.Collections.Generic;
using PrivateBlog.Domain.Entities.Clients;
using PrivateBlog.Domain.Entities.Addresses;
using PrivateBlog.Domain.Entities.OrderDetails;
using PrivateBlog.Domain.Entities.Payments;
using PrivateBlog.Domain.Entities.Shipments;

namespace PrivateBlog.Domain.Entities.Orders
{
    public sealed class Order
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public Client Client { get; private set; } = null!;
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; } = null!;
        public DateTime Date { get; private set; }
        public string State { get; private set; } = null!;
        public decimal Total { get; private set; }

        public ICollection<OrderDetail> OrderDetails { get; private set; } = new List<OrderDetail>();
        public ICollection<Payment> Payments { get; private set; } = new List<Payment>();
        public ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

        private Order() { }

        public Order(Guid clientId, Guid addressId, DateTime date, string state, decimal total)
        {
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentException("El estado es requerido.", nameof(state));
            if (total < 0) throw new ArgumentException("El total no puede ser negativo.", nameof(total));

            Id = Guid.NewGuid();
            ClientId = clientId;
            AddressId = addressId;
            Date = date;
            State = state;
            Total = total;
        }
    }
}
