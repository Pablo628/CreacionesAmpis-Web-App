using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrivateBlog.Domain.Entities.Clients;

namespace PrivateBlog.Application.Dependencies.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(Guid id);
        Task AddAsync(Client entity);
        Task UpdateAsync(Client entity);
        Task DeleteAsync(Guid id);
    }
}
