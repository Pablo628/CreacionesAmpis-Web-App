using PrivateBlog.Domain.Entities.Products;

namespace PrivateBlog.Domain.Entities.Categories
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        public ICollection<Product> Products { get; private set; } = new List<Product>();

        private Category() { }

        public Category(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("El nombre es requerido.", nameof(name));

            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
