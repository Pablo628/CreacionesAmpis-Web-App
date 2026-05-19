using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrivateBlog.Domain.Entities.Shipments;

namespace PrivateBlog.Application.Dependencies.Repositories
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<Shipment>> GetAllAsync();
        Task<Shipment?> GetByIdAsync(Guid id);
        Task AddAsync(Shipment entity);
        Task UpdateAsync(Shipment entity);
        Task DeleteAsync(Guid id);
    }
}
