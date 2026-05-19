using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrivateBlog.Domain.Entities.OrderDetails;

namespace PrivateBlog.Application.Dependencies.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail?> GetByIdAsync(Guid id);
        Task AddAsync(OrderDetail entity);
        Task UpdateAsync(OrderDetail entity);
        Task DeleteAsync(Guid id);
    }
}
