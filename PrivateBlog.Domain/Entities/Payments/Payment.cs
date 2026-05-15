using System;
using PrivateBlog.Domain.Entities.Orders;

namespace PrivateBlog.Domain.Entities.Payments
{
    public sealed class Payment
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Order Order { get; private set; } = null!;
        public string PaymentMethod { get; private set; } = null!;
        public DateTime Date { get; private set; }
        public string PaymentType { get; private set; } = null!;

        private Payment() { }

        public Payment(Guid orderId, string paymentMethod, DateTime date, string paymentType)
        {
            if (string.IsNullOrWhiteSpace(paymentMethod)) throw new ArgumentException("El método de pago es requerido.", nameof(paymentMethod));
            if (string.IsNullOrWhiteSpace(paymentType)) throw new ArgumentException("El tipo de pago es requerido.", nameof(paymentType));

            Id = Guid.NewGuid();
            OrderId = orderId;
            PaymentMethod = paymentMethod;
            Date = date;
            PaymentType = paymentType;
        }
    }
}
