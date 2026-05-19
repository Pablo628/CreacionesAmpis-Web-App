using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrivateBlog.Domain.Entities.Products;

namespace PrivateBlog.Application.Dependencies.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(Guid id);
    }
}
