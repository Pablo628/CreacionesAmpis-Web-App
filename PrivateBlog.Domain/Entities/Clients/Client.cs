using PrivateBlog.Domain.Entities.Addresses;
using PrivateBlog.Domain.Entities.Orders;

namespace PrivateBlog.Domain.Entities.Clients
{
    public sealed class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string EmailAddress { get; private set; } = null!;
        public string Tel { get; private set; } = null!;
        public bool AcceptPromotions { get; private set; }
        public string PreferredChannel { get; private set; } = null!;

        public ICollection<Address> Addresses { get; private set; } = new List<Address>();
        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        private Client() { }

        public Client(string name, string emailAddress, string tel, bool acceptPromotions, string preferredChannel)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("El nombre es requerido.", nameof(name));
            if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentException("El email es requerido.", nameof(emailAddress));
            
            Id = Guid.NewGuid();
            Name = name;
            EmailAddress = emailAddress;
            Tel = tel;
            AcceptPromotions = acceptPromotions;
            PreferredChannel = preferredChannel;
        }
    }
}
