using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrivateBlog.Domain.Entities.Addresses;

namespace PrivateBlog.Application.Dependencies.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address?> GetByIdAsync(Guid id);
        Task AddAsync(Address entity);
        Task UpdateAsync(Address entity);
        Task DeleteAsync(Guid id);
    }
}
