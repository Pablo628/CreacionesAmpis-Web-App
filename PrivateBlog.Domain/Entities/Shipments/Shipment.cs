using System;
using PrivateBlog.Domain.Entities.Orders;

namespace PrivateBlog.Domain.Entities.Shipments
{
    public sealed class Shipment
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Order Order { get; private set; } = null!;
        public string DeliveryMethod { get; private set; } = null!;
        public decimal ShippingCost { get; private set; }
        public string ShippingState { get; private set; } = null!;
        public DateTime DeliveryDate { get; private set; }

        private Shipment() { }

        public Shipment(Guid orderId, string deliveryMethod, decimal shippingCost, string shippingState, DateTime deliveryDate)
        {
            if (string.IsNullOrWhiteSpace(deliveryMethod)) throw new ArgumentException("El método de entrega es requerido.", nameof(deliveryMethod));

            Id = Guid.NewGuid();
            OrderId = orderId;
            DeliveryMethod = deliveryMethod;
            ShippingCost = shippingCost;
            ShippingState = shippingState;
            DeliveryDate = deliveryDate;
        }
    }
}
