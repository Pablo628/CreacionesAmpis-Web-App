using System;
using PrivateBlog.Persistence.Data;
using System.Collections.Generic;
using PrivateBlog.Persistence.Data;
using System.Threading.Tasks;
using PrivateBlog.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using PrivateBlog.Application.Dependencies.Repositories;
using PrivateBlog.Domain.Entities.Addresses;

namespace PrivateBlog.Persistence.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _context.Set<Address>().ToListAsync();
        }

        public async Task<Address?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Address>().FindAsync(id);
        }

        public async Task AddAsync(Address entity)
        {
            await _context.Set<Address>().AddAsync(entity);
        }

        public async Task UpdateAsync(Address entity)
        {
            _context.Set<Address>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<Address>().Remove(entity);
            }
        }
    }
}

