using System;
using PrivateBlog.Persistence.Data;
using System.Collections.Generic;
using PrivateBlog.Persistence.Data;
using System.Threading.Tasks;
using PrivateBlog.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using PrivateBlog.Application.Dependencies.Repositories;
using PrivateBlog.Domain.Entities.Payments;

namespace PrivateBlog.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Set<Payment>().ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Payment>().FindAsync(id);
        }

        public async Task AddAsync(Payment entity)
        {
            await _context.Set<Payment>().AddAsync(entity);
        }

        public async Task UpdateAsync(Payment entity)
        {
            _context.Set<Payment>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<Payment>().Remove(entity);
            }
        }
    }
}

