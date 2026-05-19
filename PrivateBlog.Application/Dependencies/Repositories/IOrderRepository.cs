using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrivateBlog.Domain.Entities.Orders;

namespace PrivateBlog.Application.Dependencies.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task AddAsync(Order entity);
        Task UpdateAsync(Order entity);
        Task DeleteAsync(Guid id);
    }
}
