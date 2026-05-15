using PrivateBlog.Domain.Entities.Clients;
using PrivateBlog.Domain.Entities.Orders;

namespace PrivateBlog.Domain.Entities.Addresses
{
    public sealed class Address
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public Client Client { get; private set; } = null!;
        public string AddressLine { get; private set; } = null!;
        public string City { get; private set; } = null!;
        public string Reference { get; private set; } = null!;

        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        private Address() { }

        public Address(Guid clientId, string addressLine, string city, string reference)
        {
            if (string.IsNullOrWhiteSpace(addressLine)) throw new ArgumentException("La dirección es requerida.", nameof(addressLine));
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("La ciudad es requerida.", nameof(city));

            Id = Guid.NewGuid();
            ClientId = clientId;
            AddressLine = addressLine;
            City = city;
            Reference = reference;
        }
    }
}
