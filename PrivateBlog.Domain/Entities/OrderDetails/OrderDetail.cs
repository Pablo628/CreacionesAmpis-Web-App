using PrivateBlog.Domain.Entities.Orders;
using PrivateBlog.Domain.Entities.Products;

namespace PrivateBlog.Domain.Entities.OrderDetails
{
    public sealed class OrderDetail
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Order Order { get; private set; } = null!;
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; } = null!;
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Subtotal { get; private set; }
        public string? Size { get; private set; }
        public string? Color { get; private set; }
        public string? PersonalizationNotes { get; private set; }

        private OrderDetail() { }

        public OrderDetail(Guid orderId, Guid productId, int quantity, decimal unitPrice, string? size, string? color, string? personalizationNotes)
        {
            if (quantity <= 0) throw new ArgumentException("La cantidad debe ser mayor que cero.", nameof(quantity));
            if (unitPrice < 0) throw new ArgumentException("El precio unitario no puede ser negativo.", nameof(unitPrice));

            Id = Guid.NewGuid();
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Subtotal = quantity * unitPrice;
            Size = size;
            Color = color;
            PersonalizationNotes = personalizationNotes;
        }
    }
}
