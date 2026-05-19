using System;
using PrivateBlog.Persistence.Data;
using System.Collections.Generic;
using PrivateBlog.Persistence.Data;
using System.Threading.Tasks;
using PrivateBlog.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using PrivateBlog.Application.Dependencies.Repositories;
using PrivateBlog.Domain.Entities.Categories;

namespace PrivateBlog.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Set<Category>().ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Category>().FindAsync(id);
        }

        public async Task AddAsync(Category entity)
        {
            await _context.Set<Category>().AddAsync(entity);
        }

        public async Task UpdateAsync(Category entity)
        {
            _context.Set<Category>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<Category>().Remove(entity);
            }
        }
    }
}

