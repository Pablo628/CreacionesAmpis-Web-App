using System;
using PrivateBlog.Persistence.Data;
using System.Collections.Generic;
using PrivateBlog.Persistence.Data;
using System.Threading.Tasks;
using PrivateBlog.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using PrivateBlog.Application.Dependencies.Repositories;
using PrivateBlog.Domain.Entities.Orders;

namespace PrivateBlog.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Set<Order>().ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Order>().FindAsync(id);
        }

        public async Task AddAsync(Order entity)
        {
            await _context.Set<Order>().AddAsync(entity);
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Set<Order>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<Order>().Remove(entity);
            }
        }
    }
}

