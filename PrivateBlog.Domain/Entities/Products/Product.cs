using PrivateBlog.Domain.Entities.Categories;
using PrivateBlog.Domain.Entities.OrderDetails;

namespace PrivateBlog.Domain.Entities.Products
{
    public sealed class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public bool IsPersonality { get; private set; }

        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; } = null!;

        public ICollection<OrderDetail> OrderDetails { get; private set; } = new List<OrderDetail>();

        private Product() { }

        public Product(string name, string description, decimal price, int stock, bool isPersonality, Guid categoryId)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("El nombre es requerido.", nameof(name));
            if (price < 0) throw new ArgumentException("El precio no puede ser negativo.", nameof(price));
            if (stock < 0) throw new ArgumentException("El stock no puede ser negativo.", nameof(stock));

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            IsPersonality = isPersonality;
            CategoryId = categoryId;
        }
    }
}
